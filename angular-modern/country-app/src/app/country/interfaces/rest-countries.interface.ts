export interface RESTCountryResponse {
    area:              number;
    cioc:              string;
    flag:              string;
    gini:              number;
    name:              string;
    flags:             Flags;
    latlng:            number[];
    region:            string;
    borders:           string[];
    capital:           string;
    demonym:           string;
    languages:         Language[];
    subregion:         string;
    timezones:         string[];
    alpha2Code:        string;
    alpha3Code:        string;
    currencies:        Currency[];
    nativeName:        string;
    population:        number;
    independent:       boolean;
    numericCode:       string;
    callingCodes:      string[];
    topLevelDomain:    string[];
    populationDensity: number;
}

export interface Currency {
    code:   string;
    name:   string;
    symbol: string;
}

export interface Flags {
    png: string;
    svg: string;
}

export interface Language {
    name:       string;
    iso639_1:   string;
    iso639_2:   string;
    nativeName: string;
}
