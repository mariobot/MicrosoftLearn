import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal } from '@angular/core';

type Item = { id: number; name: string };

@Component({
  selector: 'app-root',
  standalone: true,
  template: `
    <h3>Lists with track</h3>
    <ul>
      @for (it of items(); let i = $index; track it.id) {
        <li>{{ i + 1 }}. {{ it.name }} (id: {{ it.id }})</li>
      }
    </ul>
    <button (click)="renameFirst()">Rename first</button>
    <button (click)="shuffle()">Shuffle</button>
    <button (click)="add()">Add item</button>
  `
})
export class List2Comp {
  items = signal([
    { id: 1, name: 'Angular' },
    { id: 2, name: 'React' },
    { id: 3, name: 'Vue' }
  ]);
  nextId = 4;

  renameFirst() {
    this.items.update(arr => arr.map((it, i) => i === 0 ? { ...it, name: it.name + ' *' } : it));
  }

  shuffle() {
    this.items.update(arr => {
      const copy = [...arr];
      for (let i = copy.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [copy[i], copy[j]] = [copy[j], copy[i]];
      }
      return copy;
    });
  }

  add() {
    this.items.update(arr => [...arr, { id: this.nextId++, name: 'New ' + Date.now() }]);
  }
}

bootstrapApplication(List2Comp);
