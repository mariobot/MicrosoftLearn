import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';

@Component({
  selector: 'w3-card',
  standalone: true,
  styles: [`
    .card { border: 1px solid #ccc; border-radius: 8px; padding: 12px; max-width: 360px; }
    .card-header { font-weight: 600; margin-bottom: 6px; }
    .card-body { color: #333; }
  `],
  template: `
    <div class="card">
      <div class="card-header"><ng-content select="[card-title]"></ng-content></div>
      <div class="card-body"><ng-content></ng-content></div>
    </div>
  `
})
export class CardComponent {}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CardComponent],
  template: `
    <h3>Content Projection (ng-content)</h3>

    <w3-card>
      <span card-title>Welcome</span>
      <p>Project any markup into a reusable shell component.</p>
    </w3-card>

    <br>

    <w3-card>
      <span card-title>Another Card</span>
      <ul>
        <li>Works with lists</li>
        <li>Images, buttons, etc.</li>
      </ul>
    </w3-card>
  `
})
export class Parent {}

bootstrapApplication(Parent);