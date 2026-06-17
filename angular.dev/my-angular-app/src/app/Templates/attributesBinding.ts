import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Attribute binding (attr.)</h3>
    <button [attr.aria-label]="label" (click)="toggle()">Toggle label</button>
    <table border="1" style="margin-top:8px">
      <tr><th>A</th><th>B</th><th>C</th></tr>
      <tr><td [attr.colspan]="wide ? 2 : 1">Row 1</td><td>Cell</td><td>Cell</td></tr>
    </table>
  `
})
export class AttributesBinding {
  wide = true;
  get label() { return this.wide ? 'Table is wide' : 'Table is narrow'; }
  toggle() { this.wide = !this.wide; }
}

bootstrapApplication(AttributesBinding);