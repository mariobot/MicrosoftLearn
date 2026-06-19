import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    .box { padding: 12px; border: 2px solid #ccc; margin-top: 8px; border-radius: 6px; }
    .highlight { background: #fffa8b; }
    .big { font-size: 24px; }
    .toolbar button { margin-right: 6px; }
  `],
  template: `
    <h3>Styling</h3>
    <div class="toolbar">
      <button (click)="toggleHighlight()">Toggle Highlight</button>
      <button (click)="toggleBig()">Toggle Big</button>
      <button (click)="setColor('crimson')">Crimson</button>
      <button (click)="setColor('seagreen')">Green</button>
      <button (click)="setColor('royalblue')">Blue</button>
    </div>

    <div class="box"
      [class.highlight]="highlight"
      [ngClass]="{ big: big }"
      [style.color]="color"
      [style.borderColor]="color">
      Styled box
    </div>
  `
})
export class StyleComp {
  highlight = false;
  big = false;
  color = 'royalblue';

  toggleHighlight() { this.highlight = !this.highlight; }
  toggleBig() { this.big = !this.big; }
  setColor(c: string) { this.color = c; }
}

bootstrapApplication(StyleComp);