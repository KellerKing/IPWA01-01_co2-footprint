<script>
	import Footer from "./Footer.svelte";
	import Popup from "./Popup.svelte";
	import Header from "./Header.svelte";


	export let footerContent;
	export let direction
	export let navbarElements;

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
	
	function onLeserichtungChanged(event) {
      direction = event.detail.direction;
    }

</script>
<Header direction={direction} on:leserichtungChanged = {onLeserichtungChanged} items = {navbarElements}/>
<slot></slot>
<Footer on:popupAngefragt={handleFooterPopup} {footerContent}/>
<Popup show = {popupIsVisible} close={onPopupClosed} titel = {popupTitel} content = {popupInhalt} direction= {direction}/>

