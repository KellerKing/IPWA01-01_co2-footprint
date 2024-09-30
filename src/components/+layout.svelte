<script>
	import Footer from "./Footer.svelte";
	import Popup from "./Popup.svelte";
	import Header from "./Header.svelte";
	import { leserichtung } from "../store";

	export let footerContent;
	export let direction;
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
		leserichtung.set(event.detail.direction);
	}
</script>

<Header
	{direction}
	on:leserichtungChanged={onLeserichtungChanged}
	items={navbarElements}
/>
<div class="pt-4 px-2">
	<slot></slot>
</div>
<div class="pt-20">
	<Footer on:popupAngefragt={handleFooterPopup} {footerContent} />
</div>
<Popup
	show={popupIsVisible}
	close={onPopupClosed}
	titel={popupTitel}
	content={popupInhalt}
	{direction}
/>
