<script>
    import Popup from "../components/Popup.svelte";
    import Tabelle from "../components/Tabelle/Tabelle.svelte";
    import TextCard from "../components/TextCard.svelte";
    import { leserichtung } from "../store";
    import { onMount } from "svelte";
    import { createViewModels } from "../components/Tabelle/TabelleHelper";

    const baseAddress = "https://localhost:5001";

    let direction;
    let isWebserviceOnStartupErreichbar = true;
    let hasDatenFromWebservice = true;

    const isWebserviceErreichbar = async () => {
        try {
            let response = await fetch(baseAddress + "/IsErreichbar");
            return response.ok;
        } catch (error) {
            console.log(error);
            return false;
        }
    };

    leserichtung.subscribe((value) => {
        direction = value;
    });

    onMount(async () => {
        isWebserviceOnStartupErreichbar = await isWebserviceErreichbar();
    });

    async function updateDatenTabelle(
        landFilter,
        unternehmenFilter,
        updateMethode,
    ) {
        let daten = await getDatenTabelle(landFilter, unternehmenFilter);
        let viewModels = createViewModels(daten);
        hasDatenFromWebservice = daten && daten.length > 0;

        updateMethode(viewModels);
    }

    async function getDatenTabelle(landFilter, unternehmenFilter) {
        let address = baseAddress + "/GetCo2Verbrauch";

        landFilter = sanitizeString(landFilter);
        if (!isStringEmpty(landFilter)) {
            address += "/land/" + landFilter;
        }

        unternehmenFilter = sanitizeString(unternehmenFilter);
        if (!isStringEmpty(unternehmenFilter)) {
            address += "/unternehmen/" + unternehmenFilter;
        }

        try {
            let response = await fetch(address);
            let data = await response.json();
            return data;
        } catch (error) {
            Error(error.Message);
        }
    }

    function isStringEmpty(str) {
        return !str || str.length === 0 || str === "";
    }

    function sanitizeString(str) {
        if (!str) return null;
        let text = str.replace(/</g, "&lt;").replace(/>/g, "&gt;").trim();
        return text;
    }
</script>

<TextCard>
    <div dir={direction}>
        <p>adjökasd</p>
    </div>
</TextCard>

{#if isWebserviceOnStartupErreichbar}
    <Tabelle
        {direction}
        on:FilterTabelle={(event) =>
            updateDatenTabelle(
                event.detail.filterLand,
                event.detail.filterUnternehmen,
                event.detail.updateMethode,
            )}
    />
{:else}
    <Popup
        show={true}
        titel="Webservice ist nicht erreichbar."
        content="<p>Der Webservice ist momentan nicht erreichbar. Die Tabelle mit dem Co2 Vergleich kann daher nicht geladen werden.
              Zum erneuten Verbindungsversuch, laden sie bitte die Seite mit der Taste F5 neu oder versuchen sie es zu einem späteren Zeitpunkt erneut.</p>"
        {direction}
    />
{/if}

{#if !hasDatenFromWebservice}
    <Popup
        show={true}
        titel="Keine Suchergebnisse bei gewählem Filter"
        content="<p>Bei der eingegebenen Filterkombination aus Land und Unternehmen konnten keine Ergebnisse gefunden werden</p>"
        {direction}
    />
{/if}
