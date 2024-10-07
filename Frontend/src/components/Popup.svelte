<script>
  export let show = false;
  export let close = () => {};
  export let titel = "";
  export let content = "";
  export let direction;
</script>

  {#if show}
	<div class="fixed inset-0 bg-gray-500 bg-opacity-75 flex items-center justify-center md:min-w-72 min-w-40 max-w-full px-10 overflow-y-auto" dir={direction}>
	  <div class="bg-white p-4 rounded shadow-lg">
		<h1 class="text-lg pb-4">{@html titel}</h1>
		<p>{@html content}</p>
		<button class="mt-4 bg-gray-700 text-white p-2 rounded transition-all duration-200 hover:bg-green-600 w-full text-lg" on:click={close}>Schließen</button>
	  </div>
	</div>
  {/if}