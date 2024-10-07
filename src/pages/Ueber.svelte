<script>
    import { leserichtung } from "../store";
    import TextCard from "../components/TextCard.svelte";

    let direction;
    leserichtung.subscribe((value) => {
        direction = value;
    });
</script>

<TextCard>
    <div dir={direction}>
        <p>
            Diese Seite hat keine größere Funktion. Sie sit nur dazu da um das navigieren über das Menü zu verdeutlichen.
            Zwei Menüeinträge sieht, meiner Meinung nach, zu wenig aus um verlässlich die Funktion darzustellen. 
        </p>
    </div>
</TextCard>
