import { ChangeDetectionStrategy, Component } from '@angular/core';
import { SearchInput } from "../../components/search-input/search-input";
import { CountryList } from "../../components/country-list/country-list";

@Component({
  selector: 'app-by-region-page',
  imports: [SearchInput, CountryList],
  templateUrl: './by-region-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ByRegionPage {

}
