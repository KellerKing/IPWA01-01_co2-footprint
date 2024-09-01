<script>
  export let show = false;
  export let close = () => {};
  export let titel = "";
  export let content = "";
</script>

  {#if show}
	<div class="fixed inset-0 bg-gray-500 bg-opacity-75 flex items-center justify-center">
	  <div class="bg-white p-4 rounded shadow-lg">
		<h2>{titel}</h2>
		<p>{content}</p>
		<button class="mt-4 bg-red-500 text-white p-2 rounded" on:click={close}>Schließen</button>
	  </div>
	</div>
  {/if}