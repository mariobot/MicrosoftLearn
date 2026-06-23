import { bootstrapApplication } from '@angular/platform-browser';
import { Component, EventEmitter, Output, Input, signal } from '@angular/core';
import { NgComponentOutlet } from '@angular/common';

@Component({
  standalone: true,
  template: `<button (click)="clicked.emit()">{{ label }}</button>`
})
export class ActionButton {
  @Input() label = 'Do it';
  @Output() clicked = new EventEmitter<void>();
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [NgComponentOutlet],
  template: `
    <h3>Selectorless via *ngComponentOutlet</h3>
    <p>Clicks: {{ clicks() }}</p>
    <ng-container *ngComponentOutlet="ActionButton; inputs: { label: 'Launch' }; outputs: { clicked: onClick }"></ng-container>
  `
})
export class ChangeDetection2Comp {
  ActionButton = ActionButton;
  clicks = signal(0);
  onClick = () => this.clicks.update(n => n + 1);
}

bootstrapApplication(ChangeDetection2Comp);