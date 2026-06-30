import { ChangeDetectionStrategy, Component } from '@angular/core';
import { GiftListItem } from "../gift-list-item/gift-list-item";

@Component({
  selector: 'app-gift-list',
  imports: [GiftListItem],
  templateUrl: './gift-list.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GiftList {}
