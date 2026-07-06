import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CountryService } from '../../services/country-service';
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';
import { NotFound } from "../../../shared/components/not-found/not-found";
import { CountryInformation } from "./country-information/country-information";

@Component({
  selector: 'app-country-page',
  imports: [NotFound, CountryInformation],
  templateUrl: './country-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryPage {

  codeCountry = inject(ActivatedRoute).snapshot.paramMap.get('code') || '';
  countryService = inject(CountryService);
  country = signal<RESTCountryResponse>({} as RESTCountryResponse);
  isError = signal<string | null>(null);

  constructor() {
    if (this.codeCountry) {
      this.countryService.searchCountryByCode(this.codeCountry)
        .subscribe({
          next: (country) => {
            console.log('Country data:', country);
            this.country.set(country);
          },
          error: (error) => {
            console.error('Error fetching country data:', error);
            this.isError.set(error.message);
          }
        });
    }
  }
}
