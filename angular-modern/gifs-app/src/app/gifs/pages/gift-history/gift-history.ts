import { Component, computed, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { map } from 'rxjs';
import { GifService } from '../../services/gifts.service';
import { GiftList } from "../../component/gift-list/gift-list";

@Component({
  selector: 'app-gift-history',
  imports: [GiftList],
  templateUrl: './gift-history.html',
})
export default class GiftHistory {

  gifService = inject(GifService);

  query = toSignal(
    inject(ActivatedRoute).params.pipe(
      map((params) => params['query'])
    )
  );

  gifsByKey = computed(() => {
    const query = this.query();
    return query ? this.gifService.getHistoryGifts(query) : [];
  });
}


