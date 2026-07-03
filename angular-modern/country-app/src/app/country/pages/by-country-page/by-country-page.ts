import { ChangeDetectionStrategy, Component, inject, input, signal } from '@angular/core';
import { SearchInput } from "../../components/search-input/search-input";
import { CountryList } from "../../components/country-list/country-list";
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';
import { CountryService } from '../../services/country-service';

@Component({
  selector: 'app-by-country-page',
  imports: [SearchInput, CountryList],
  templateUrl: './by-country-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ByCountryPage {

  countries = signal<RESTCountryResponse[]>([]);
  countryService = inject(CountryService);

  isLoading = signal(false);
  isError = signal<string | null>(null);

  onSearchCountry(searchTerm: string): void {
    if (this.isLoading()) return;

    this.isLoading.set(true);
    this.isError.set(null);

    this.countryService.searchByCountry(searchTerm)
      .subscribe({
        next: (countries) => {
          this.isLoading.set(false);
          this.countries.set(countries);
        },
        error: (error) => {
          this.isLoading.set(false);
          this.countries.set([]);
          this.isError.set(error.message);
        }
      });
  }
}
