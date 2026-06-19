import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>Pipes</h3>
    <p>{{ title | uppercase }}</p>
    <p>{{ price | currency:'USD' }}</p>
    <p>{{ today | date:'mediumDate' }}</p>
    <p>{{ percent | percent:'1.0-2' }}</p>
  `
})
export class PipesComp {
  title = 'Angular';
  price = 1234.5;
  today = new Date();
  percent = 0.3495;
}

bootstrapApplication(PipesComp);