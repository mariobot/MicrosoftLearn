import { HttpClient } from "@angular/common/http";
import { computed, inject, Injectable, signal } from "@angular/core";
import { environment } from "@environments/environment";
import type { GiphyResponse } from "../interfaces/giphy.interface";
import { Gif } from "../interfaces/gift.inteface";
import { GifMapper } from "../mapper/gift.mapper";
import { map, tap } from "rxjs";

@Injectable({providedIn:'root'})
export class GifService{
    constructor(){
        this.loadTrendingGifs();
    }

    private http = inject(HttpClient)

    trandingGifs = signal<Gif[]>([]);
    trendingGifsLoading = signal(true);

    seachHistory = signal<Record<string, Gif[]>>({});
    searchHistoryKeys= computed(() => Object.keys(this.seachHistory()));

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

    searchGifts(query: string){
        return this.http.get<GiphyResponse>(`${ environment.giphyUrl}/gifs/search`, {
            params: {
                api_key: environment.giphyApiKey,
                limit: 20,
                q: query
            }        
        })
        .pipe(
            map((resp) => {
                const gifts = GifMapper.mapGiphyItemToGifArray(resp.data);
                return gifts;
            }),
            tap(items => {
                this.seachHistory.update((history) => ({
                    ...history,
                    [query.toLowerCase()]: items
                }));
            })
        );
    }
}