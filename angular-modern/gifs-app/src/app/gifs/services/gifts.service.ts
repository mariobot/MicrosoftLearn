import { HttpClient } from "@angular/common/http";
import { computed, effect, inject, Injectable, signal } from "@angular/core";
import { environment } from "@environments/environment";
import type { GiphyResponse } from "../interfaces/giphy.interface";
import { Gif } from "../interfaces/gift.inteface";
import { GifMapper } from "../mapper/gift.mapper";
import { map, tap } from "rxjs";

const loadFromLocalStorage = (): Record<string, Gif[]> => {
    const history = localStorage.getItem('giftsHistory');
    return history ? JSON.parse(history) : {};
}

@Injectable({providedIn:'root'})
export class GifService{
    constructor(){
        this.loadTrendingGifs();
    }

    private http = inject(HttpClient)

    trandingGifs = signal<Gif[]>([]);
    trendingGifsLoading = signal(false);
    private trendingPage = signal(0);
    trendingGiftGroup = computed<Gif[][]>(() => {
        const groups: Gif[][] = [];
        for (let index = 0; index < this.trandingGifs().length; index++) {
            const element = this.trandingGifs()[index];
            if (index % 3 === 0) {
                groups.push([]);
            }
            groups[groups.length - 1].push(element);
        }
        return groups;
    });

    seachHistory = signal<Record<string, Gif[]>>(loadFromLocalStorage());
    searchHistoryKeys= computed(() => Object.keys(this.seachHistory()));
    
    
    saveGiftsToLocalStorage = effect(() => {
        const history = this.seachHistory();
        localStorage.setItem('giftsHistory', JSON.stringify(history));
    });
    
    loadTrendingGifs(){

        if(this.trendingGifsLoading()) return;
        this.trendingGifsLoading.set(true);

        this.http.get<GiphyResponse>(`${ environment.giphyUrl}/gifs/trending`, {
            params: {
                api_key: environment.giphyApiKey,
                limit: 20,
                offset: this.trendingPage() * 20
            }
        }).subscribe((resp) => {
            const gifts = GifMapper.mapGiphyItemToGifArray(resp.data)
            this.trandingGifs.update((current) => [...current, ...gifts]);
            this.trendingGifsLoading.set(false);
            this.trendingPage.update((page) => page + 1);
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

    getHistoryGifts(query: string){
        return this.seachHistory()[query.toLowerCase()] || [];
    }
}