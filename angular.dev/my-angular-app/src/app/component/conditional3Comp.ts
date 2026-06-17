import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-root',
  standalone: true,
  styles: [`
    .toolbar { display: flex; gap: 8px; align-items: center; flex-wrap: wrap; }
  `],
  template: `
    <h3>Multi-state with if</h3>

    <div class="toolbar">
      <button (click)="startLoading()">Start Loading</button>
      <button (click)="showError()">Set Error</button>
      <button (click)="reset()">Reset</button>
      <span style="margin-left:8px;color:#666">loading={{ loading() }} error={{ error() }}</span>
    </div>

    @if (!loading() && !error()) {
      <p>Content loaded successfully.</p>
    } @else if (loading()) {
      <p>Loading...</p>
    } @else {
      <p style="color:crimson">Something went wrong.</p>
    }
  `
})
export class Conditional3Comp {
  loading = signal(false);
  error = signal(false);
  private _timer: any;

  startLoading() {
    this.loading.set(true);
    this.error.set(false);
    clearTimeout(this._timer);
    this._timer = setTimeout(() => {
      this.loading.set(false);
    }, 800);
  }
  showError() {
    this.error.set(true);
    this.loading.set(false);
  }
  reset() {
    this.loading.set(false);
    this.error.set(false);
  }
}

bootstrapApplication(Conditional3Comp);