import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { SearchInput } from "../../components/search-input/search-input";
import { CountryList } from "../../components/country-list/country-list";
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';

@Component({
  selector: 'app-by-country-page',
  imports: [SearchInput, CountryList],
  templateUrl: './by-country-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ByCountryPage {

  countries = input<RESTCountryResponse[]>([]);

}
