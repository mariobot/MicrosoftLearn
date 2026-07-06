import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { RESTCountryResponse } from '../../../interfaces/rest-countries.interface';
import { DecimalPipe } from '@angular/common';

@Component({
  selector: 'app-country-information',
  imports: [DecimalPipe],
  templateUrl: './country-information.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryInformation {
  country = input.required<RESTCountryResponse>();
}
