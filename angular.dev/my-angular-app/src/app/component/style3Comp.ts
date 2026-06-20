import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    :host { --bg: #ffffff; --fg: #222; --accent: #4169e1; }
    .theme-dark { --bg: #121212; --fg: #eaeaea; --accent: #4f8cff; }
    .toolbar { display: flex; gap: 8px; align-items: center; }
    .swatch { width: 18px; height: 18px; border-radius: 50%; border: 1px solid #ccc; display: inline-block; vertical-align: middle; }
    .box { margin-top: 10px; padding: 14px; border-radius: 8px; border: 2px solid var(--accent); background: var(--bg); color: var(--fg); transition: all .15s ease-in-out; }
    button { padding: 6px 10px; }
  `],
  template: `
    <h3>Theme with CSS Variables</h3>
    <div [class.theme-dark]="dark" class="toolbar">
      <button (click)="dark = !dark">Toggle {{ dark ? 'Light' : 'Dark' }}</button>
      <button (click)="setAccent('#e91e63')">Pink</button>
      <button (click)="setAccent('#00b894')">Green</button>
      <button (click)="setAccent('#ff9800')">Orange</button>
      <span class="swatch" [style.background]="accent"></span>
    </div>

    <div class="box" [style.--accent]="accent">
      This box follows the current theme and accent color.
    </div>
  `
})
export class Style3Comp {
  dark = false;
  accent = '#4169e1';

  setAccent(c: string) { this.accent = c; }
}

bootstrapApplication(Style3Comp);