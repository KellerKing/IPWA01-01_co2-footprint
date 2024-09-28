import Startseite from "./pages/Startseite.svelte";
import Co2Vergleich from "./pages/Co2Vergleich.svelte";
import Ueber from "./pages/Ueber.svelte";

const routen = {
    '/': Startseite,
    '/Co2Vergleich': Co2Vergleich,
    '/About' : Ueber 
};

export default routen