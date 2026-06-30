import { ChangeDetectionStrategy, Component } from '@angular/core';
import { GiftList } from "../../component/gift-list/gift-list";

@Component({
  selector: 'app-trading-page',
  imports: [GiftList],
  templateUrl: './trading-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class TradingPage {}
