<script>
    import { onMount } from "svelte";
    export let tableData;

    let currentSortierung = { Property: "", IsAufsteigend: false };
    let sucheLand;
    let sucheUnternehmen;

    onMount(() => {
        if (tableData?.length <= 0) return;
        viewData = tableData;

        sortByHeader(Object.keys(viewData[0])[0]);
    });

    $: viewData = filterDaten(sucheLand, sucheUnternehmen, viewData, tableData);

    function translatePropertyInUeberschrift(property) {
        switch (property.toUpperCase()) {
            case "LAND":
                return "Land";
            case "UNTERNEHMEN":
                return "Unternehmen";
            case "CO2INGRAMMPROSTUNDEBETRIEB":
                return "CO2-Fußabdruck in pro Betriebsstunde";
            case "BRANCHE":
                return "Branche";
            default:
                return "";
        }
    }

    function updateCurrentSortierung(nameProperty) {
        //Erster Aufruf kommt vom onMount event.
        if (!currentSortierung.Property) {
            currentSortierung.IsAufsteigend = true;
            currentSortierung.Property = nameProperty;
            return;
        }

        currentSortierung.IsAufsteigend =
            currentSortierung.Property === nameProperty &&
            !currentSortierung.IsAufsteigend;
        currentSortierung.Property = nameProperty;
    }

    function sortByHeader(nameProperty) {
        updateCurrentSortierung(nameProperty);
        let reihenfolge = currentSortierung.IsAufsteigend ? 1 : -1;

        //Fall 1: Absteigend
        //Wenn a kleiner b ist, dann muss b vor a. Also -1 * -1 = 1. Dann wird b nach vorne/oben geschoben.
        //Wenn a größer b ist, dann muss a...
        let sorter = (a, b) =>
            a[nameProperty] < b[nameProperty]
                ? -1 * reihenfolge
                : a[nameProperty] > b[nameProperty]
                  ? 1 * reihenfolge
                  : 0;

        //tableData = tableData.sort(sorter);
        viewData = viewData.sort(sorter);
    }

    function getSortierungssymbol(kopfzeile) {
        if (currentSortierung.Property === kopfzeile) {
            return currentSortierung.IsAufsteigend ? "&#x25b4" : "&#x25be";
        }

        return "&#x25b4;&#x25be";
    }

    function filterDaten(
        filterLandString,
        filterUnternehmenString,
        viewData,
        tableData,
    ) {
        if (!viewData || viewData.length <= 0) return tableData;

        if (!filterLandString && !filterUnternehmenString) {
            viewData.forEach((element) => {
                element.IsVisible = true;
            });
            return viewData;
        }

        viewData.forEach((element) => {
            element.IsVisible = false;
        });

        let result = [];

        if (filterLandString) {
            let gefunden = viewData.filter((datensatz) => datensatz.Land.toUpperCase().includes(filterLandString.toUpperCase())); 
            gefunden.forEach(element => result.push(element));
        }

        if (filterUnternehmenString) {
            let gefunden = viewData.filter((datensatz) =>datensatz.Unternehmen.toUpperCase().includes(filterUnternehmenString.toUpperCase())); 
            gefunden.forEach(element => result.push(element));
        }
        console.log("result:");
        console.log(result);
        result.forEach((element) => {
            element.IsVisible = true;
        });

        return viewData;
    }
</script>

{#if tableData?.length > 0}
    <div>
        <div>
            <label for="filterLand">Filter nach Land</label>
            <input
                type="text"
                placeholder="z.b Deutschland"
                id="filterLand"
                bind:value={sucheLand}
            />

            <label for="filterUnternehmen">Filter nach Unternehmen</label>
            <input
                type="text"
                placeholder="z.b SAP"
                id="filterUnternehmen"
                bind:value={sucheUnternehmen}
            />
        </div>
        <div>
            <thead>
                <tr>
                    {#each Object.keys(viewData[0]) as kopfzeile}
                        {#if translatePropertyInUeberschrift(kopfzeile)}
                            <th
                                id={kopfzeile}
                                on:click={() => sortByHeader(kopfzeile)}
                            >
                                {translatePropertyInUeberschrift(kopfzeile)}
                                {@html getSortierungssymbol(kopfzeile)}
                            </th>
                        {/if}
                    {/each}
                </tr>
            </thead>
            <tbody>
                {#each Object.values(viewData) as datensatz}
                    {#if datensatz.IsVisible}
                        {#each Object.values(datensatz) as property}
                            {#if typeof property != "boolean"}
                                <td>{property}</td>
                            {/if}
                        {/each}
                    {/if}
                    <tr> </tr>
                {/each}
            </tbody>
        </div>
    </div>
{/if}

<style>
    table,
    th,
    td {
        border: 1px solid;
        border-collapse: collapse;
        margin: 10px;
    }
</style>
