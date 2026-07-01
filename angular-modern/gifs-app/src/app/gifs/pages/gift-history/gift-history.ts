import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { toSignal } from '@angular/core/rxjs-interop';
import { map, Observable } from 'rxjs';

@Component({
  selector: 'app-gift-history',
  imports: [],
  templateUrl: './gift-history.html',
})
export default class GiftHistory {
  query = toSignal(
    inject(ActivatedRoute).params.pipe(
      map((params) => params['query'])
    )
  );
}


