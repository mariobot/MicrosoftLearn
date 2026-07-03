import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { RESTCountryResponse } from '../../interfaces/rest-countries.interface';
import { DecimalPipe } from '@angular/common';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-country-list',
  imports: [DecimalPipe, RouterLink],
  templateUrl: './country-list.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryList {
  countries = input.required<RESTCountryResponse[]>();
}
