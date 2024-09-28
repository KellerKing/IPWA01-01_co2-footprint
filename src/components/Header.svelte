<script>
  import src from "../assets/logo_iu.svg";
  import { createEventDispatcher } from "svelte";
  import { onMount } from "svelte";
  import {link} from 'svelte-spa-router';

  export let direction;
  export let items;
  const dispatch = createEventDispatcher();

  let isNavigationVisible = false;
  let isRightToLeft = false;

  onMount(() => {
    isRightToLeft =
      direction &&
      direction.localeCompare("rtl", undefined, { sensitivity: "accent" }) == 0;
  });

  function onToggleLeserichtung() {
    dispatch("leserichtungChanged", {
      direction: isRightToLeft ? "rtl" : "ltr",
    });
  }
</script>

<header>
  <nav>
    <div class="flex flex-wrap items-center justify-between mx-auto p-4">
      <img
        {src}
        class="h-12 flex items-center space-x-3 rtl:space-x-reverse"
        alt="Logo"
      />
      <button
        type="button"
        class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none"
        on:click={() => {
          isNavigationVisible = !isNavigationVisible;
        }}
      >
        <svg
          class="w-5 h-5"
          xmlns="http://www.w3.org/2000/svg"
          fill="none"
          viewBox="0 0 17 14"
        >
          <path
            stroke="currentColor"
            stroke-linecap="round"
            stroke-linejoin="round"
            stroke-width="2"
            d="M1 1h15M1 7h15M1 13h15"
          />
        </svg>
      </button>
      <div
        class="w-full md:block md:w-auto {isNavigationVisible
          ? ''
          : 'hidden'} md:visible"
      >
        <ul
          class="font-medium flex flex-col p-4 md:p-0 mt-4 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 bg-gray-700 rounded md:bg-transparent"
        >
          {#each items as currentItem}
            <li>
              <a
                href={currentItem.Link} use:link
                id={currentItem.Id}
                class="block py-1 px-2 mb-1 md:text-black text-gray-100 md:p-0 hover:text-green-600 hover:underline"
              >
                {currentItem.Text}
              </a>
            </li>
          {/each}
        </ul>
      </div>
    </div>
  </nav>
  <div class="inline-flex px-2 mt-5 mb-5">
    <label
      for="toggleLeserichtung"
      class="text-slate-600 text-sm px-2">Von links nach rechts</label
    >
    <div class="relative inline-block w-11 h-5">
      <input
        id="toggleLeserichtung"
        type="checkbox"
        bind:checked={isRightToLeft}
        on:change={onToggleLeserichtung}
        class="peer appearance-none w-11 h-5 bg-slate-200 rounded-full checked:bg-slate-600 cursor-pointer transition-colors duration-200"
      />
      <label
        for="toggleLeserichtung"
        class="absolute top-0 left-0 w-5 h-5 bg-white rounded-full border border-slate-300 shadow-sm transition-transform duration-200 peer-checked:translate-x-6 peer-checked:border-slate-800 cursor-pointer"
      >
      </label>
    </div>

    <label
      for="toggleLeserichtung"
      class="text-slate-600 text-sm px-2">Von rechts nach links</label
    >
  </div>
</header>
