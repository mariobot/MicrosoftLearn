import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';

const BASE_URL = 'https://api.restcountries.com/countries/v5/capitals';
const COUNTRIES_DEV_URL = 'pp';

@Injectable({
  providedIn: 'root',
})
export class CountryService {

  private http = inject(HttpClient);

  searchByCapital(capital: string) {
    //const url = `${BASE_URL}?q=${capital}&limit=5&pretty=1&api-key=rc_live_03db3bd7f40f447d936bac514910c364`;
    const url = `${COUNTRIES_DEV_URL}/${capital}`;
    return this.http.get(url);
  }

}
