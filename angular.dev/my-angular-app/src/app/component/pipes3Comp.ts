import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Pipe, PipeTransform } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Pipe({ name: 'titlecase2', standalone: true })
export class TitleCase2Pipe implements PipeTransform {
  transform(value: string): string {
    if (!value) return '';
    return value
      .split(/\s+/)
      .map(w => w.charAt(0).toUpperCase() + w.slice(1).toLowerCase())
      .join(' ');
  }
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule, TitleCase2Pipe],
  template: `
    <h3>Custom Pipe</h3>
    <label>
      Text: <input [(ngModel)]="text" placeholder="type here" />
    </label>
    <p>Original: {{ text }}</p>
    <p>TitleCase2: {{ text | titlecase2 }}</p>
  `
})
export class Pipes3Comp {
  text = 'hello angular pipes';
}

bootstrapApplication(Pipes3Comp);