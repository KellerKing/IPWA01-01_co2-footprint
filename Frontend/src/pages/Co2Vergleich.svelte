<script>
    import datenTabelle from "../lib/tabellendaten";
    import Tabelle from "../components/Tabelle/Tabelle.svelte";
    import TextCard from "../components/TextCard.svelte";
    import { leserichtung } from "../store";

    let direction;
    leserichtung.subscribe((value) => {
        direction = value;
    });
</script>

<TextCard>
    <div dir={direction}>
        <p>adjökasd</p>
    </div>
</TextCard>
<Tabelle data={datenTabelle} {direction} />
