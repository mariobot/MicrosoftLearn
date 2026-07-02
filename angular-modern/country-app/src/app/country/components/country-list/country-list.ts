import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-country-list',
  imports: [DecimalPipe],
  templateUrl: './country-list.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryList {
  countries = input.required<RESTCountryResponse[]>();
}
