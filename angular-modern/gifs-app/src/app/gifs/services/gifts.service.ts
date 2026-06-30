import { HttpClient } from "@angular/common/http";
import { inject, Injectable } from "@angular/core";
import { environment } from "@environments/environment";
import type { GiphyResponse } from "../interfaces/giphy.interface";

@Injectable({providedIn:'root'})
export class GifService{
    constructor(){
        this.loadTrendingGifs();
    }

    private http = inject(HttpClient)

    loadTrendingGifs(){
        return this.http.get<GiphyResponse>(`${ environment.giphyUrl}/gifs/trending`, {
            params: {
                api_key: environment.giphyApiKey,
                limit: 20
            }
        })
    }
}