import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { environment } from "@environments/environment";
import type { GiphyResponse } from "../interfaces/giphy.interface";
import { Gif } from "../interfaces/gift.inteface";
import { GifMapper } from "../mapper/gift.mapper";

@Injectable({providedIn:'root'})
export class GifService{
    constructor(){
        this.loadTrendingGifs();
    }

    private http = inject(HttpClient)

    trandingGifs = signal<Gif[]>([]);
    trendingGifsLoading = signal(true);

    loadTrendingGifs(){
        this.http.get<GiphyResponse>(`${ environment.giphyUrl}/gifs/trending`, {
            params: {
                api_key: environment.giphyApiKey,
                limit: 20
            }
        }).subscribe((resp) => {
            const gifts = GifMapper.mapGiphyItemToGifArray(resp.data)
            this.trandingGifs.set(gifts);
            this.trendingGifsLoading.set(false);
            console.log({gifts});
        });
    }
}