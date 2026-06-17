import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { App } from '../app';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  styles: [`
    table { border-collapse: collapse; margin-top: 10px; }
    th, td { border:1px solid #ccc; padding:8px 10px; }
    .toolbar { display:flex; gap:10px; align-items:center; }
  `],
  template: `
    <h3>Attribute Binding (attr.*)</h3>

    <div class="toolbar">
      <label>Colspan: <input type="range" min="1" max="3" [value]="span" (input)="span = +$any($event.target).value"> {{ span }}</label>
      <label>Title: <input [value]="title" (input)="title = $any($event.target).value"></label>
    </div>

    <table [attr.title]="title">
      <thead>
        <tr><th>A</th><th>B</th><th>C</th></tr>
      </thead>
      <tbody>
        <tr>
          <td [attr.colspan]="span" style="background:#f9fbff">colspan={{ span }}</td>
          <td *ngIf="span < 2">B</td>
          <td *ngIf="span < 3">C</td>
        </tr>
      </tbody>
    </table>
  `
})
export class AttrBinding {
  span = 1;
  title = 'Data table';
}

bootstrapApplication(AttrBinding);