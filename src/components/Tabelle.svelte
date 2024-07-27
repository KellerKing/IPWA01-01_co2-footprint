<script>
    export let tableData;

    function translatePropertyInUeberschrift(property) {
        switch (property.toUpperCase()) {
            case "LAND":
                return "Land";
            case "UNTERNEHMEN":
                return "Unternehmen";
            case "CO2INGRAMMPROSTUNDEBETRIEB":
                return "CO2-Fußabdruck in pro Betriebsstunde";
            case "BRANCHE":
                return "Branche";
            default:
                return property;
        }
    }
</script>

{#if tableData?.length > 0}
    <div>
        <thead>
            <tr>
                {#each Object.keys(tableData[0]) as kopfzeile}
                    <th>{translatePropertyInUeberschrift(kopfzeile)}</th>
                {/each}
            </tr>
        </thead>
        <tbody>
            {#each Object.values(tableData) as datensatz}
                <tr>
                    {#each Object.values(datensatz) as property}
                        <td>{property}</td>
                    {/each}
                </tr>
            {/each}
        </tbody>
    </div>
{/if}

<style>
    table,
    th,
    td {
        border: 1px solid;
        border-collapse: collapse;
        margin: 10px;
    }
</style>
