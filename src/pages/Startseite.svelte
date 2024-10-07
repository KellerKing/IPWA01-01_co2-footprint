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
      Dies ist die Startseite für Aufgabe 1.1 des Kurses <b
        >IPWA01-01 Programmierung von Webanwendungsoberflächen</b
      >.
    </p>
    <h2 class="pb-2 text-xl pt-6">Aufbau der Seite:</h2>
    <p>
      Oben recht befindet sich ein Menü. Darüber kann auf die verschiedenen
      Seite navigiert werden. Die Hauptaufgabe, der Filterbaren Tabelle,
      befindet sich auf der Seite "Fußabdruck im Vergleich". Wenn die Seite auf
      Geräten mit niedriger Auflösung in der Breite angeschaut wird, wird das
      Menü als "Hamburger Menü" dargstellt.
      <br>
      Über den Schalter links oben unter halb des Logos, können Texte von der leserichtung angepasst werden. Je nach der eingestellten Sprache des Browsers setzt sich dieser Wert von selbst. 
      <br>
      Klickt man auf einen Eintrag im Footer öffnet sich ein entsprechendes Popup mit z.B einem fiktiven Impressum.
      <br><br>
      Im Allgemeinen wurde darauf geachtet, dass die Webseite auch auf mobilen Geräten funktioniert und bedienbar ist.
    </p>
  </div>
</TextCard>
