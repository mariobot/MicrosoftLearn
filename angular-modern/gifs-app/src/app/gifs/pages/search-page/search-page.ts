import { Component, inject, signal } from '@angular/core';
import { GiftList } from "../../component/gift-list/gift-list";
import { GifService } from '../../services/gifts.service';
import { Gif } from '../../interfaces/gift.inteface';

@Component({
  selector: 'app-search-page',
  imports: [GiftList],
  templateUrl: './search-page.html',
})
export default class SearchPage {

  gifService = inject(GifService);
  gifs = signal<Gif[]>([])

  onSearch(query: string) {
    this.gifService.searchGifts(query).subscribe((gifts) => {
      this.gifs.set(gifts);
    });
  }
}
