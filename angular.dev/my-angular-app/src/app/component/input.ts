import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'hello-comp',
  standalone: true,
  template: `<p>Hello {{ name }} from child!</p>`
})
export class HelloComponent {
  @Input() name = '';
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [HelloComponent],
  template: `
    <h3>Parent Component</h3>
    <hello-comp [name]="user"></hello-comp>
  `
})
export class InputComponent {
  user = 'Angular';
}

bootstrapApplication(InputComponent);