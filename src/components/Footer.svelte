<script>
    import { createEventDispatcher } from "svelte";
    import Popup from "./Popup.svelte";

    const dispatch = createEventDispatcher();

    let showModal = false;

    function toggleModal() {
        showModal = !showModal;
    }

    function onImpressumClicked() {
        //toggleModal();

        dispatch("popupAngefragt", {
            Titel: "Impressum",
            Inhalt: "Das ist der Impressum Inhalt"
        });
    }

    function onDatenschutzClicked() {
        //toggleModal();

        dispatch("popupAngefragt", {
            Titel: "Datenschutz",
            Inhalt: "Das ist der Datenschutzinhalt"
        });
    }
</script>

<!--class="justify-center inset-x-0 h-16 bg-green-200 flex flex-row fixed bottom-0 left-0 w-full"-->
<div class="h-20 bg-green-200 fixed bottom-0 left-0 w-full">
    <div class="flex justify-center gap-4 p-4">
        <div class="border-2">
            <button type="button" on:click={onImpressumClicked} class = "mx-2">
                Impressum
            </button>
        </div>
        <div class="">
            <button type="button" on:click={onDatenschutzClicked}>
                Datenschutz
            </button>
        </div>
    </div>
</div>

<Popup show = {showModal} close={toggleModal} />
