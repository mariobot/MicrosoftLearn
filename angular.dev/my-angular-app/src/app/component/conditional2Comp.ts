import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Conditional Rendering with switch</h3>
    <label>
      Status:
      <select (change)="status.set($any($event.target).value)">
        <option value="loading">loading</option>
        <option value="success">success</option>
        <option value="error">error</option>
      </select>
    </label>

    @switch (status()) {
      @case ('loading') { <p>Loading...</p> }
      @case ('success') { <p>Success!</p> }
      @case ('error') { <p style="color:crimson">Error!</p> }
      @default { <p>Unknown status</p> }
    }
  `
})
export class Conditional2Comp {
  status = signal<'loading' | 'success' | 'error' | string>('loading');
}

bootstrapApplication(Conditional2Comp);