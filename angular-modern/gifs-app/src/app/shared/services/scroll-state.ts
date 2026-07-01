import { inject, Injectable, signal } from '@angular/core';

@Injectable({providedIn:'root'})
export class ScrollStateService {
  
    tredingScrollState = signal(0);

    
}