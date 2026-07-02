import { ChangeDetectionStrategy, Component, input, output } from '@angular/core';

@Component({
  selector: 'app-search-input',
  imports: [],
  templateUrl: './search-input.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SearchInput {
  value = output<string>();
  placeholder = input<string>('Buscar');
}
