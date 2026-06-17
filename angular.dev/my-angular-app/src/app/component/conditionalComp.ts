import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Conditional Rendering</h3>
    <button (click)="show.set(!show())">Toggle</button>
    @if (show()) { <p>Now you see me!</p> } @else { <p>Now I'm hidden.</p> }
  `
})
export class ConditionalComp {
  show = signal(true);
}

bootstrapApplication(ConditionalComp);