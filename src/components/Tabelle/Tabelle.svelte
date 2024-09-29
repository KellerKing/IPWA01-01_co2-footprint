<script>
    import { onMount } from "svelte";
    import {
        createViewModels,
        getSortedViewModels,
        getFilteredDaten,
        getUeberschriftSpalte,
    } from "./TabelleHelper.js";

    //Daten aus tabellendaten.js
    export let data;
    export let direction;

    let currentSortierung = { Property: "", IsAufsteigend: false };
    let sucheLand;
    let sucheUnternehmen;

    onMount(() => {
        if (data?.length <= 0) return;

        viewModels = createViewModels(data);

        sortByHeader("Land");
    });

    $: viewModels = getFilteredDaten(sucheLand, sucheUnternehmen, viewModels);

    function updateCurrentSortierung(nameProperty) {
        //Erster Aufruf kommt vom onMount event.
        if (!currentSortierung.Property) {
            currentSortierung.IsAufsteigend = true;
            currentSortierung.Property = nameProperty;
            return;
        }

        currentSortierung.IsAufsteigend =
            currentSortierung.Property === nameProperty &&
            !currentSortierung.IsAufsteigend;
        currentSortierung.Property = nameProperty;
    }

    function sortByHeader(nameProperty) {
        updateCurrentSortierung(nameProperty);
        viewModels = getSortedViewModels(
            viewModels,
            currentSortierung.IsAufsteigend,
            currentSortierung.Property,
        );
    }

    function getSortierungssymbol(kopfzeile) {
        if (currentSortierung.Property === kopfzeile) {
            return currentSortierung.IsAufsteigend ? "&#x25b4" : "&#x25be";
        }

        return "&#x25b4;&#x25be";
    }

    function getKlassenTableRow(index) {
        let result = "hover:bg-slate-200";

        result += index % 2 == 0 ? " bg-gray-100" : " bg-white";
        return result;
    }

    function handleInput(event) {
        //Sanitisation. 
        let text = event.target.value.replace(/</g, "&lt;").replace(/>/g, "&gt;");

        if (event.target.id === "filterLand") {
            sucheLand = text.trim();
            return;
        }
        sucheUnternehmen = text.trim();
    }
</script>

{#if viewModels?.length > 0}
    <div dir="{direction}">
        <div class="pt-5 rounded max-w-md md:max-w-4xl px-5">
            <div
                class="grid grid-rows-1 md:grid-rows-1 grid-cols-1 md:grid-cols-2 gap-3"
            >
                <div class="mb-3">
                    <label for="filterLand" class="font-medium"
                        >Filter nach Land</label
                    >
                    <input
                        type="text"
                        placeholder="z.b Deutschland"
                        maxlength="30"
                        id="filterLand"
                        class="border rounded w-full py-2 px-3 text-gray-700 leading-tight bg-gray-200 focus:bg-white"
                        on:input={handleInput}
                    />
                </div>
                <div class="mb-6">
                    <label for="filterUnternehmen" class="font-medium"
                        >Filter nach Unternehmen</label
                    >
                    <input
                        type="text"
                        placeholder="z.b Volkswagen"
                        maxlength="30"
                        id="filterUnternehmen"
                        class="border rounded w-full py-2 px-3 text-gray-700 leading-tight bg-gray-200 focus:bg-white"
                        on:input={handleInput}
                    />
                </div>
            </div>
        </div>
        <div
            class="pt-4 md:mx-auto h-96 md:h-full overflow-y-auto md:max-w-6xl"
        >
            <table
                class="shadow-xl bg-gray-100 rounded-xl border-separate border-1
                transform-gpu w-full"
            >
                <thead class="bg-slate-700 text-white shadow-sm text-sm">
                    {#each Object.keys(viewModels[0]) as kopfzeile}
                        {#if getUeberschriftSpalte(kopfzeile)}
                            <th
                                id={kopfzeile}
                                on:click={() => sortByHeader(kopfzeile)}
                                class="p-2"
                            >
                                {getUeberschriftSpalte(kopfzeile)} <br>
                                {@html getSortierungssymbol(kopfzeile)}
                            </th>
                        {/if}
                    {/each}
                </thead>
                <tbody class="border-2">
                    {#each viewModels.filter((v) => v.IsVisible) as datensatz, i}
                        <tr class="{getKlassenTableRow(i)}">
                            {#each Object.values(datensatz) as property}
                                {#if typeof property != "boolean"}
                                    <td>{property}</td>
                                {/if}
                            {/each}
                        </tr>
                    {/each}
                </tbody>
            </table>
        </div>
    </div>
{/if}