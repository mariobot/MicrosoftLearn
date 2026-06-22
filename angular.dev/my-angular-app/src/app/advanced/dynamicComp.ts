import { bootstrapApplication } from '@angular/platform-browser';
import { Component, EventEmitter, Output, Input, ElementRef, ViewChild, inject, EnvironmentInjector, ComponentRef } from '@angular/core';
import { createComponent } from '@angular/core';

@Component({
  standalone: true,
  template: `
    <div style="padding:8px;border:1px solid #ddd;border-radius:6px;">
      <h4 style="margin:0 0 8px 0;">{{ title }}</h4>
      <button (click)="clicked.emit()">Click</button>
    </div>
  `
})
export class Card {
  @Input() title = 'Card';
  @Output() clicked = new EventEmitter<void>();
}

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Dynamic createComponent()</h3>
    <div #host style="min-height:60px;border:1px dashed #aaa;padding:8px;border-radius:6px;"></div>
    <div style="margin-top:8px;display:flex;gap:8px;flex-wrap:wrap;">
      <button (click)="mount()">Mount</button>
      <button (click)="update()">Update input</button>
      <button (click)="unmount()">Unmount</button>
    </div>
  `
})
export class DynamicComp {
  @ViewChild('host', { read: ElementRef }) host!: ElementRef<HTMLElement>;
  env: EnvironmentInjector = inject(EnvironmentInjector);
  ref: ComponentRef<Card> | null = null;

  mount() {
    if (this.ref) return;
    this.ref = createComponent(Card, {
      environmentInjector: this.env,
      hostElement: this.host.nativeElement
    });
    this.ref.setInput?.('title', 'Hello from Dynamic');
    this.ref.instance.clicked.subscribe(() => alert('Card clicked'));
  }
  update() {
    if (!this.ref) return;
    this.ref.setInput?.('title', 'Updated Title ' + new Date().toLocaleTimeString());
  }
  unmount() {
    this.ref?.destroy();
    this.ref = null;
  }
}

bootstrapApplication(DynamicComp);