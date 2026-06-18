import { bootstrapApplication } from '@angular/platform-browser';
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <h3>Reactive Forms</h3>
    <form [formGroup]="form" (ngSubmit)="onSubmit()">
      <label>
        Name
        <input formControlName="name" placeholder="Your name">
      </label>
      <div *ngIf="form.controls.name.invalid && (form.controls.name.dirty || form.controls.name.touched || submitted)" style="color:crimson">
        <small *ngIf="form.controls.name.errors && form.controls.name.errors['required']">Name is required.</small>
        <small *ngIf="form.controls.name.errors && form.controls.name.errors['minlength']">Min 3 characters.</small>
      </div>

      <label>
        Email
        <input formControlName="email" placeholder="you@example.com">
      </label>
      <div *ngIf="form.controls.email.invalid && (form.controls.email.dirty || form.controls.email.touched || submitted)" style="color:crimson">
        <small *ngIf="form.controls.email.errors && form.controls.email.errors['required']">Email is required.</small>
        <small *ngIf="form.controls.email.errors && form.controls.email.errors['email']">Email must be valid.</small>
      </div>

      <label>
        <input type="checkbox" formControlName="newsletter">
        Subscribe to newsletter
      </label>

      <button type="submit" [disabled]="form.invalid">Submit</button>
    </form>

    <p>Status: {{ form.status }}</p>
    <p>Value: {{ form.value | json }}</p>
    <p *ngIf="submitted" style="color: seagreen;">Submitted!</p>
  `
})
export class Form3Comp {
  fb = new FormBuilder();
  submitted = false;
  form = this.fb.group({
    name: ['', [Validators.required, Validators.minLength(3)]],
    email: ['', [Validators.required, Validators.email]],
    newsletter: [false],
  });

  onSubmit() { this.submitted = true; }
}

bootstrapApplication(Form3Comp);