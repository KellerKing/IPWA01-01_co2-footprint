<script>
  import src from "../assets/logo_iu.svg";

  let expanded = false;

  let items = [
    { text: "Startseite", link: "#" },
    { text: "Fußabdruck im vergleich", link: "#" },
    { text: "Über die Seite", link: "#" },
  ];
</script>

<!--https://svelte.dev/repl/f4bbc54bdb1b470c8aaafae6145a5537?version=3.43.2-->
<header>
  <nav class="">
    <div class="flex flex-wrap items-center justify-between mx-auto p-4">
      <a href="#" class="flex items-center space-x-3 rtl:space-x-reverse">
        <img {src} class="h-12" alt="Logo" />
      </a>
      <button
        data-collapse-toggle="navbar-default"
        type="button"
        class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200"
        aria-controls="navbar-default"
        aria-expanded={expanded}
        on:click={() => { expanded = !expanded; }}>
        <svg
          class="w-5 h-5"
          aria-hidden="true"
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
      <div class="w-full md:block md:w-auto" id="navbar-default">
        <ul
          class="{expanded ? '' : 'hidden'} font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0">
          {#each items as currentItem}
            <li>
              <a
                href={currentItem.link}
                class="block py-2 px-3 bg-blue-700 rounded md:bg-transparent md:text-blue-700 md:p-0"
                aria-current="page">{currentItem.text}</a>
            </li>
            {/each}
        </ul>
      </div>
    </div>
  </nav>
</header>

<style>
/*  .header {
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    padding: 20px 100px;
    background-color: lightblue;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 100;
  }

  .navigation a {
    position: relative;
    font-size: 18px;
    color: white;
    font-weight: 500;
    text-decoration: none;
    margin-left: 40px;
  }

  .navigation a::before {
    content: "";
    position: absolute;
    top: 100%;
    left: 0;
    height: 3px;
    width: 0%;
    background-color: lightgreen;
    transition: 200ms;
  }

  .navigation a:hover::before {
    width: 100%;
  } */
</style>
