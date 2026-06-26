import { Component, signal } from "@angular/core";

@Component({
    template: `
        <h1>Counter {{ counter }}</h1>
        <h2>Counter Signal {{ counterSignal() }}</h2>
        <p>counter component</p>
        <button (click)="increment(1)" >+1</button>
        <button (click)="increment(-1)" >-1</button>
        <button (click)="reset()" >Reset</button>
    `,
})

export class CounterPageComponent {
    counter = 10;
    counterSignal = signal(10);

    increment(value: number) {
        this.counter += value;
        this.counterSignal.update((current) => current + value);
    }
    reset() {
        this.counter = 10;
        this.counterSignal.set(10)
    }
}