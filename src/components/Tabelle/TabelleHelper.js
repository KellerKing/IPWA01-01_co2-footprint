import { TabelleViewModel } from "./TabelleViewModel";

export function createViewModels(data) {
    let result = [];

    data.forEach(element => {
        let viewModel = new TabelleViewModel(element.Unternehmen, element.Land, element.Branche, rundeVerbrauch(element.Co2InTonnen));
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


export function getFilteredDaten(
    filterLandString,
    filterUnternehmenString,
    viewData) {
    if (!viewData || viewData.length <= 0) return [];

    if (!filterLandString && !filterUnternehmenString) {
        viewData.forEach((element) => {
            element.IsVisible = true;
        });
        return viewData;
    }

    viewData.forEach((element) => {
        element.IsVisible = false;
    });

    let result = [];

    getFilteredViewModels(viewData, filterLandString, "land").forEach(element => {
        result.push(element);
    });

    getFilteredViewModels(viewData, filterUnternehmenString, "unternehmen").forEach(element => {
        result.push(element);
    });

    result.forEach((element) => {
        element.IsVisible = true;
    });

    return viewData;
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

function getFilteredViewModels(viewData, filterString, key) {
    let result = []
    if (!filterString) return result;

    let gefunden = viewData.filter((datensatz) =>
        datensatz[key].toUpperCase().includes(
            filterString.toUpperCase(),
        ),
    );
    gefunden.forEach((element) => result.push(element));
    return result;
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