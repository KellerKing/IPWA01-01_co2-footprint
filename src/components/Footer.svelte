<script>
    import { createEventDispatcher } from "svelte";

    export let footerContent;

    const dispatch = createEventDispatcher();

    function onFooterItemClicked(button) {
        let id = parseInt(button.id);
        let element = footerContent.find(x => x.Id == id);
        if (element == null) return;
        
        dispatch("popupAngefragt", {
            Titel: element.Titel,
            Inhalt: element.Content,
        });
    }
</script>

<div class="h-16 bg-gray-800 bg-opacity-95 fixed bottom-0 left-0 w-full">
    <div class="flex justify-center gap-4 p-4 text-lg text-white">
        {#each footerContent as item}
            <div class="">
                <button
                    type="button"
                    id={item.Id}
                    on:click={(event) => onFooterItemClicked(event.target)}
                    class="hover:text-xl transition-all duration-500 hover:text-green-600"
                >
                    {@html item.Text}
                </button>
            </div>
        {/each}
    </div>
</div>
