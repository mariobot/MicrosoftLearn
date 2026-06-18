import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <h3>Forms Validation</h3>
    <form #f="ngForm" (ngSubmit)="onSubmit()" novalidate>
      <label>
        Name:
        <input name="name" [(ngModel)]="model.name" required minlength="3" #name="ngModel">
      </label>
      <div *ngIf="name.invalid && (name.dirty || name.touched || submitted)" style="color:crimson">
        <small *ngIf="name.errors && name.errors['required']">Name is required.</small>
        <small *ngIf="name.errors && name.errors['minlength']">Name must be at least 3 characters.</small>
      </div>

      <label>
        Email:
        <input name="email" [(ngModel)]="model.email" email required #email="ngModel">
      </label>
      <div *ngIf="email.invalid && (email.dirty || email.touched || submitted)" style="color:crimson">
        <small *ngIf="email.errors && email.errors['required']">Email is required.</small>
        <small *ngIf="email.errors && email.errors['email']">Email must be valid.</small>
      </div>

      <button type="submit" [disabled]="f.invalid">Submit</button>
    </form>

    <p *ngIf="submitted">Submitted: {{ model | json }}</p>
  `
})
export class Form2Comp {
  model = { name: '', email: '' };
  submitted = false;
  onSubmit() { this.submitted = true; }
}

bootstrapApplication(Form2Comp);