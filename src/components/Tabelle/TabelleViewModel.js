export class TabelleViewModel {
    unternehmen;
    land;
    branche;
    co2Verbrauch;
    isVisible = true;

    constructor(unternehmen, land, branche, co2Verbrauch) {
        this.unternehmen = unternehmen;
        this.land = land;
        this.branche = branche;
        this.co2Verbrauch = co2Verbrauch;
    }

    static isNumber(nameProperty) {
        return nameProperty.toLowerCase() === "co2verbrauch";
    }
}