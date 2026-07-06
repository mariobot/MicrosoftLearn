import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CountryService } from '../../services/country-service';
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';

@Component({
  selector: 'app-country-page',
  imports: [],
  templateUrl: './country-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryPage {

  codeCountry = inject(ActivatedRoute).snapshot.paramMap.get('code') || '';
  countryService = inject(CountryService);
  country = signal<RESTCountryResponse | null>(null);

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
          }
        });
    }
  }
}
