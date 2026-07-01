import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterOutlet } from "@angular/router";

@Component({
  selector: 'app-country-layout',
  imports: [RouterOutlet],
  templateUrl: './country-layout.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CountryLayout {}
