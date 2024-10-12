import { TabelleViewModel } from "./TabelleViewModel";

export function createViewModels(data) {
    let result = [];

    data.forEach(element => {
        let viewModel = new TabelleViewModel(element.unternehmen, element.land, element.branche, rundeVerbrauch(element.co2Verbrauch));
        result.push(viewModel)
    });

    return result;
}

function rundeVerbrauch(verbrauch) {
    return verbrauch.toFixed(2);
}

export function getSortedViewModels(viewModels, isAufsteigend, nameProperty) {
    let sorter;

    if (TabelleViewModel.isNumber(nameProperty)) sorter = getSorterNumber(isAufsteigend, nameProperty);
    else sorter = getSorterString(isAufsteigend, nameProperty);

    return viewModels.sort(sorter);
}


export function getUeberschriftSpalte(property) {
    switch (property.toUpperCase()) {
        case "LAND":
            return "Land";
        case "UNTERNEHMEN":
            return "Unternehmen";
        case "CO2VERBRAUCH":
            return "Co2-Emissionen*";
        case "BRANCHE":
            return "Branche";
        default:
            return "";
    }
}


function getSorterString(isAufsteigend, nameProperty) {
    let reihenfolge = isAufsteigend ? 1 : -1;

    let sorter = (a, b) =>
        a[nameProperty] < b[nameProperty]
            ? -1 * reihenfolge
            : a[nameProperty] > b[nameProperty]
                ? 1 * reihenfolge
                : 0;

    return sorter;
}

//Weil der String "91" größer als "101" ist, muss eine Zahl vorher als Foat gewandelt werden.
function getSorterNumber(isAufsteigend, nameProperty) {
    let reihenfolge = isAufsteigend ? 1 : -1;

    let sorter = (a, b) =>
        parseFloat(a[nameProperty]) < parseFloat(b[nameProperty])
            ? -1 * reihenfolge
            : parseFloat(a[nameProperty]) > parseFloat(b[nameProperty])
                ? 1 * reihenfolge
                : 0;

    return sorter;

}