<script>
  import Layout from "./components/+layout.svelte";

  import Router from "svelte-spa-router";
  import routes from "./routes";
  import { navbarElements } from "./routes";

  let direction = setDefaultLeserichtung();


  function createFooterContent() {
    return [
      {
        Text: "Impressum",
        Id: 1,
        Titel: "Impressum",
        Content:
          "Angaben gemäß § 5 DDG<br/><br/>" +
          "Max Muster <br/>Musterweg<br/>" +
          "12345 Musterstadt<br/>" +
          "Vertreten durch: Max Muster<br/>" +
          "Kontakt: -<br/>" +
          "Telefon: 01234-789456 </br>" +
          "Fax: 1234-56789 <br/>" +
          "E-Mail: max@muster.de<br/><br/>" +
          "Umsatzsteuer-ID: - <br/>" +
          "Umsatzsteuer-Identifikationsnummer gemäß §27a<br/>" +
          "Umsatzsteuergesetz: Musterustid.<br/><br/>" +
          "Wirtschafts-ID: Musterwirtschaftsid<br/><br/>" +
          "<p><b> Hinweis:</b> Das kein echtes Impressum, sondern soll nur den Vorgaben der Aufgabe entsprechen.<br/>" +
          "Erstellt mit einem <a href='https://www.impressum-generator.de/impressum-generator'> Generator</a> </p>",
      },
      {
        Text: "Datenschutz",
        Id: 2,
        Titel: "Datenschutz",
        Content:
          "<p>Das ist eine Demonstration des Footers mit Popup. Hier können informationen zum Datenschutz eingetragen werden." +
          "Da dies keine richtige Webseite ist, wird auf einen ordentlichen Datenschutzeintrag verzichtet.</p>",
      },
    ];
  }

  function onLeserichtungChanged(event) {
    direction = event.detail.direction;
  }

  function setDefaultLeserichtung() {
    let defaultDirection = "ltr";
    try {
      let userLang = navigator.language;
      let locale = new Intl.Locale(userLang);
      // @ts-ignore
      return locale.textInfo.direction || defaultDirection;
    } catch {
      return defaultDirection;
    }
  }

  function createHeaderItemsFromRoutes() {
    let result = [];

    navbarElements.forEach(element => {
      let text = "";
    
      if (element.name.toLowerCase() === "startseite") text = "Startseite";
      else if (element.name.toLowerCase() === "co2vergleich") text = "Fußabdruck im vergleich";
      else if (element.name.toLowerCase() === "about") text = "Über die Seite";
      else text = element.name;
      
      let item = {
        Id: element.id,
        Text: text,
        Link: element.link
      };
        result.push(item);
    });

    return result.sort(x => x.Id);
  }
  
</script>

<Layout footerContent={createFooterContent()} {direction} navbarElements = {createHeaderItemsFromRoutes()}>
  <Router {routes} />
</Layout>
