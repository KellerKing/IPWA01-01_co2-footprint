<script>
  import svelteLogo from './assets/svelte.svg'
  import viteLogo from '/vite.svg'
  import Counter from './lib/Counter.svelte'
  import Header from './components/Header.svelte'
  import Footer from './components/Footer.svelte'
  import Tabelle from './components/Tabelle/Tabelle.svelte'
  import {datenTabelle} from './lib/tabellendaten.js'
  import { getContext } from "svelte";
  import Popup from './components/Popup.svelte'

  let popupIsVisible = false;
  let popupTitel = "";
  let popupInhalt = "";

  function handleFooterPopup(event) {
    popupTitel = event.detail.Titel;
    popupInhalt = event.detail.Inhalt;
    popupToggleIsVisible();
  }

  function popupToggleIsVisible() {
        popupIsVisible = !popupIsVisible;
    }

    function onPopupClosed() {
      popupTitel = "";
      popupInhalt = "";
      popupToggleIsVisible();
    }
</script>

<body>
  <Header/>
  <Tabelle data = {datenTabelle}/>
  <main>
  </main>
  <Footer on:popupAngefragt={handleFooterPopup}/>
  <Popup show = {popupIsVisible} close={onPopupClosed} titel = {popupTitel} content = {popupInhalt}/>

</body>



<!--
 <main>
  <div>
    <a href="https://vitejs.dev" target="_blank" rel="noreferrer">
      <img src={viteLogo} class="logo" alt="Vite Logo" />
    </a>
    <a href="https://svelte.dev" target="_blank" rel="noreferrer">
      <img src={svelteLogo} class="logo svelte" alt="Svelte Logo" />
    </a>
  </div>
  <h1>Vite + Svelte</h1>

  <div class="card">
    <Counter />
  </div>

  <p>
    Check out <a href="https://github.com/sveltejs/kit#readme" target="_blank" rel="noreferrer">SvelteKit</a>, the official Svelte app framework powered by Vite!
  </p>

  <p class="read-the-docs">
    Click on the Vite and Svelte logos to learn more
  </p>
</main>

<style>
  .logo {
    height: 6em;
    padding: 1.5em;
    will-change: filter;
    transition: filter 300ms;
  }
  .logo:hover {
    filter: drop-shadow(0 0 2em #646cffaa);
  }
  .logo.svelte:hover {
    filter: drop-shadow(0 0 2em #ff3e00aa);
  }
  .read-the-docs {
    color: #888;
  }
</style> -->
