import { ChangeDetectionStrategy, Component, inject, resource, signal } from '@angular/core';
import { SearchInput } from "../../components/search-input/search-input";
import { CountryList } from "../../components/country-list/country-list";
import { CountryService } from '../../services/country-service';
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';

@Component({
  selector: 'app-by-capital-page',
  imports: [SearchInput, CountryList],
  templateUrl: './by-capital-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ByCapitalPage {
  countryService = inject(CountryService);
  /*query = signal<string>('');

  countryResource = resource({
    request: () => ({ queery: this.query()}),
    loader: async () = {
      if(!request.query()) return [];
    }
    });
  */

  isLoading = signal(false);
  isError = signal<string | null>(null);

  countries = signal<RESTCountryResponse[]>([]);

  onSearchCapital(searchTerm: string): void {
    if (this.isLoading()) return;

    this.isLoading.set(true);
    this.isError.set(null);

    this.countryService.searchByCapital(searchTerm)
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
