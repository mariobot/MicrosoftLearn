import { ChangeDetectionStrategy, Component, ElementRef, inject, viewChild } from '@angular/core';
import { GiftList } from "../../component/gift-list/gift-list";
import { GifService } from '../../services/gifts.service';

const imageUrls: string[] = [
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-1.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-2.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-3.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-4.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-5.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-6.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-7.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-8.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-9.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-10.jpg",
    "https://flowbite.s3.amazonaws.com/docs/gallery/square/image-11.jpg"
];

@Component({
  selector: 'app-trading-page',
  //imports: [GiftList],
  templateUrl: './trading-page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export default class TradingPage {
  //gifts = imageUrls
  gifsServie = inject(GifService);

  scrolDivRef = viewChild<ElementRef>('scroll');

  onScroll(event: Event) {
    const scrollDiv = this.scrolDivRef()?.nativeElement as HTMLDivElement;
    if(!scrollDiv) return;
    const scrollTop = scrollDiv.scrollTop;
    const scrollHeight = scrollDiv.scrollHeight;
    const clientHeight = scrollDiv.clientHeight;
    //console.log('scrollTop', scrollTop);
    //console.log('scrollHeight', scrollHeight);
    //console.log('clientHeight', clientHeight);
    //console.log('scroll event', event);

    const isAtBottom = scrollTop + clientHeight + 300 >= scrollHeight;
    if (isAtBottom) {
      console.log('Reached the bottom of the div!');
      
      this.gifsServie.loadTrendingGifs();
    }
  }
}
