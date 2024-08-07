<script>
    import { onMount } from "svelte";
    import {createViewModels, getSortedViewModels, getFilteredDaten, getUeberschriftSpalte } from "./TabelleHelper.js"
    export let data;

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
        viewModels = getSortedViewModels(viewModels, currentSortierung.IsAufsteigend, currentSortierung.Property);
    }

    function getSortierungssymbol(kopfzeile) {
        if (currentSortierung.Property === kopfzeile) {
            return currentSortierung.IsAufsteigend ? "&#x25b4" : "&#x25be";
        }

        return "&#x25b4;&#x25be";
    }

    function getKlassenTableRow(index) {
        let result = "";

        result += index % 2 == 0 ? " bg-gray-100" : " bg-white";
        return result;
    }
</script>

{#if viewModels?.length > 0}
    <div>
        <div class="pt-5 rounded max-w-md md:max-w-4xl px-5">
            <div class="grid grid-rows-1 md:grid-rows-1 grid-cols-1 md:grid-cols-2 gap-3">
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
                        bind:value={sucheLand}
                    />
                </div>
                <div class="mb-6">
                    <label for="filterUnternehmen" class="font-medium"
                        >Filter nach Unternehmen</label
                    >
                    <input
                        type="text"
                        placeholder="z.b SAP"
                        maxlength="30"
                        id="filterUnternehmen"
                        class="border rounded w-full py-2 px-3 text-gray-700 leading-tight bg-gray-200 focus:bg-white"
                        bind:value={sucheUnternehmen}
                    />
                </div>
            </div>
        </div>
        <div class="w-full pt-4 bg-green-100 justify-center flex">
            <table
                class="shadow-xl bg-gray-100 md:w-5/6 lg:w-2/3 rounded-xl border-separate border-1 overflow-scroll transform-gpu scale-80 md:scale-100"
            >
                <thead class="bg-slate-700 text-white shadow-sm">
                    {#each Object.keys(viewModels[0]) as kopfzeile}
                        {#if getUeberschriftSpalte(kopfzeile)}
                            <th
                                id={kopfzeile}
                                on:click={() => sortByHeader(kopfzeile)}
                                class="p-3"
                            >
                                {getUeberschriftSpalte(kopfzeile)}
                                {@html getSortierungssymbol(kopfzeile)}
                            </th>
                        {/if}
                    {/each}
                </thead>
                <tbody class="border-2">
                    {#each Object.values(viewModels) as datensatz, i}
                        <tr class="hover:bg-slate-200 {getKlassenTableRow(i)}">
                            {#if datensatz.IsVisible}
                                {#each Object.values(datensatz) as property}
                                    {#if typeof property != "boolean"}
                                        <td>{property}</td>
                                    {/if}
                                {/each}
                            {/if}
                        </tr>
                    {/each}
                </tbody>
            </table>
        </div>
    </div>
{/if}

<style>
</style>
