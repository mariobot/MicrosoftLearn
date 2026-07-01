import { Gif } from "../interfaces/gift.inteface";
import { GiphyItem } from "../interfaces/giphy.interface";

export class GifMapper{
    static mapGiphyItemToGif(item: GiphyItem): Gif{
        return{
            id: item.id,
            title: item.title,
            url: item.images.original.url
        }
    }

    static mapGiphyItemToGifArray(item: GiphyItem[]): Gif[]{
        return item.map(this.mapGiphyItemToGif)
    }
}