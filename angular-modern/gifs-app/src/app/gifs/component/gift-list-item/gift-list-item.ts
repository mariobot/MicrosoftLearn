import { ChangeDetectionStrategy, Component } from '@angular/core';

@Component({
  selector: 'app-gift-list-item',
  imports: [],
  templateUrl: './gift-list-item.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GiftListItem {}
