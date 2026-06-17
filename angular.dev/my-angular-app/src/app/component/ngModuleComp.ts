import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h3>Two-way Binding (ngModel)</h3>

    <label>
      Name: <input [(ngModel)]="name" placeholder="Type your name" />
    </label>

    <label style="margin-left:12px">
      Favorite:
      <select [(ngModel)]="favorite">
        <option value="Angular">Angular</option>
        <option value="TypeScript">TypeScript</option>
        <option value="JavaScript">JavaScript</option>
      </select>
    </label>

    <p>Hello {{ name || 'friend' }}!</p>
    <p>Favorite: {{ favorite }}</p>
  `
})
export class NgModuleComp {
  name = 'Angular';
  favorite = 'Angular';
}

bootstrapApplication(NgModuleComp);