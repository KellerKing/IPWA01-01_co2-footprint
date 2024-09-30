<script>
  import TextCard from "../components/TextCard.svelte";
  import { leserichtung } from "../store";

  let direction;
  leserichtung.subscribe((value) => {
    direction = value;
  });
</script>

<TextCard>
  <div dir={direction}>
    <h1 class="pb-2 text-2xl">Willkommen!</h1>
    <p class="md:text-base text-xl">
      Dies ist die Startseite für Aufgabe zwei meines Studienprojekts. Hier
      präsentiere ich stolz mein erstes Projekt mit Webtechnologien, das mit
      Svelte entwickelt wurde. Svelte hat mir die Möglichkeit gegeben, moderne
      und reaktive Benutzeroberflächen zu erstellen, und ich freue mich, die
      Ergebnisse meiner Arbeit mit dir zu teilen.
      <br /><br />
      Durch die Beschäftigung mit Svelte habe ich nicht nur neue technische Fähigkeiten
      erlernt, sondern auch viel über die Gestaltung benutzerfreundlicher Webanwendungen
      erfahren. Ich lade dich ein, die verschiedenen Aspekte des Projekts zu erkunden
      und mir dein Feedback zu hinterlassen.
      <br /><br />
      Viel Spaß beim Stöbern!
    </p>
  </div>
</TextCard>
