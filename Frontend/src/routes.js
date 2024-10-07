import Startseite from "./pages/Startseite.svelte";
import Co2Vergleich from "./pages/Co2Vergleich.svelte";
import Ueber from "./pages/Ueber.svelte";


export const navbarElements = [
    {id: 1, name: "Startseite", link: '/'},
    {id: 2, name: "Co2Vergleich", link: '/Co2Vergleich'},
    {id: 3, name: "About", link: '/About'},
];


const routen = {
    '/': Startseite ,
    '/Co2Vergleich': Co2Vergleich,
    '/About' : Ueber
};

export default routen