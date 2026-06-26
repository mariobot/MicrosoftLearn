import { Component } from "@angular/core";

@Component({
    template: `
        <h1>Counter {{ counter }}</h1>
        <p>counter component</p>
        <button (click)="increment(1)" >+1</button>
    `,
})

export class CounterPageComponent {
    counter = 0;
    increment(value: number) {
        this.counter += value;
    }
}