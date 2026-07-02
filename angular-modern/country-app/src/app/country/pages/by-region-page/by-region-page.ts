import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { SearchInput } from "../../components/search-input/search-input";
import { CountryList } from "../../components/country-list/country-list";
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';

@Component({
  selector: 'app-by-region-page',
  imports: [SearchInput, CountryList],
  templateUrl: './by-region-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ByRegionPage {

  countries = input<RESTCountryResponse[]>([]);
}
