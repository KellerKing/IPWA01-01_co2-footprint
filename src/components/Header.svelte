<script>
  import src from "../assets/logo_iu.svg";

  let isNavigationVisible = false;

  let items = [
    { Id: "1", Text: "Startseite", Link: "#" },
    { Id: "2", Text: "Fußabdruck im vergleich", Link: "#" },
    { Id: "3", Text: "Über die Seite", Link: "#" },
  ];

</script>

<header>
  <nav class="">
    <div class="flex flex-wrap items-center justify-between mx-auto p-4">
      <a href="#" class="flex items-center space-x-3 rtl:space-x-reverse">
        <img {src} class="h-12" alt="Logo" />
      </a>
      <button
        type="button"
        class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none"
        on:click={() => { isNavigationVisible = !isNavigationVisible;}}>
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
      <div class="w-full md:block md:w-auto {isNavigationVisible ? '' : 'hidden'} md:visible">
        <ul
          class="font-medium flex flex-col p-4 md:p-0 mt-4 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 bg-gray-700 rounded md:bg-transparent"
        >
          {#each items as currentItem}
            <li>
              <a
                href={currentItem.Link}
                id={currentItem.Id}
                class="block py-1 px-2 mb-1 md:text-black text-gray-100 md:p-0 hover:text-green-600 hover:underline">
                {currentItem.Text}
                </a>
            </li>
          {/each}
        </ul>
      </div>
    </div>
  </nav>
</header>