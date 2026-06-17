import { bootstrapApplication } from '@angular/platform-browser';
import { Component, Directive, Input, HostBinding, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';

@Directive({
  selector: '[w3Highlight]',
  standalone: true
})
export class HighlightDirective {
  @Input('w3Highlight') highlightColor = 'lightyellow';
  @HostBinding('style.transition') transition = 'background-color 150ms ease-in-out';
  @HostBinding('style.backgroundColor') bg = '';

  @HostListener('mouseenter') onEnter() { this.bg = this.highlightColor; }
  @HostListener('mouseleave') onLeave() { this.bg = ''; }
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HighlightDirective],
  styles: [`
    .box { padding: 10px; border: 1px dashed #bbb; border-radius: 6px; }
  `],
  template: `
    <h3>Attribute Directive (highlight)</h3>
    <p>Hover the first box to see the effect:</p>
    <div class="box" [w3Highlight]="'lightyellow'">I get highlighted on hover</div>
    <div class="box" style="margin-top:8px">I do not</div>
  `
})
export class AttrDirective {}

bootstrapApplication(AttrDirective);