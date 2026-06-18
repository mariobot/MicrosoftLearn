import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h3>Forms</h3>
    <form #f="ngForm" (ngSubmit)="onSubmit()">
      <label>
        Name:
        <input name="name" [(ngModel)]="name" placeholder="Enter your name">
      </label>
      <button type="submit">Submit</button>
    </form>
    <p>Value: {{ name }}</p>
    <p *ngIf="submitted">Submitted!</p>
  `
})
export class FormComp {
  name = '';
  submitted = false;
  onSubmit() { this.submitted = true; }
}

bootstrapApplication(FormComp);