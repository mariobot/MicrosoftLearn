import { ChangeDetectionStrategy, Component, input } from '@angular/core';
import { GiftListItem } from "../gift-list-item/gift-list-item";
import { Gif } from '../../interfaces/gift.inteface';

@Component({
  selector: 'app-gift-list',
  imports: [GiftListItem],
  templateUrl: './gift-list.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class GiftList {
  gifts = input.required<Gif[]>()
}
