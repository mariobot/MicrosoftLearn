import { bootstrapApplication } from '@angular/platform-browser';
import { Component, signal, computed } from '@angular/core';
import { CommonModule } from '@angular/common';

type Product = { name: string; price: number };

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  template: `
    <h3>Filter & Sort</h3>
    <div style="display:flex;gap:8px;margin-bottom:8px;">
      <label>Search: <input #q (input)="query.set(q.value)" placeholder="Type to filter..." /></label>
      <button (click)="setSort('name')">Sort by Name</button>
      <button (click)="setSort('price')">Sort by Price</button>
      <button (click)="toggleDir()">{{ sortDir() === 1 ? 'Asc' : 'Desc' }}</button>
    </div>

    <table style="width:100%;border-collapse:collapse;">
      <thead>
        <tr><th style="border:1px solid #ddd;padding:8px;background:#f7f7f7;">Name</th><th style="border:1px solid #ddd;padding:8px;background:#f7f7f7;width:140px;">Price</th></tr>
      </thead>
      <tbody>
        @for (p of view(); track p.name) {
          <tr>
            <td style="border:1px solid #ddd;padding:8px;">{{ p.name }}</td>
            <td style="border:1px solid #ddd;padding:8px;">{{ p.price | currency:'USD' }}</td>
          </tr>
        }
      </tbody>
    </table>
  `
})
export class List3Comp {
  items = signal<Product[]>([
    { name: 'Angular', price: 0 },
    { name: 'React', price: 0 },
    { name: 'Vue', price: 0 },
    { name: 'Svelte', price: 0 },
    { name: 'Solid', price: 0 },
    { name: 'Lit', price: 0 }
  ]);
  query = signal('');
  sortKey = signal<'name' | 'price'>('name');
  sortDir = signal<1 | -1>(1); // 1 asc, -1 desc

  view = computed(() => {
    const q = this.query().toLowerCase();
    const dir = this.sortDir();
    const key = this.sortKey();
    return this.items()
      .filter(it => it.name.toLowerCase().includes(q))
      .sort((a, b) => {
        const av: any = (a as any)[key];
        const bv: any = (b as any)[key];
        return av < bv ? -1 * dir : av > bv ? 1 * dir : 0;
      });
  });

  setSort(key: 'name' | 'price') {
    if (this.sortKey() === key) {
      this.toggleDir();
    } else {
      this.sortKey.set(key);
    }
  }

  toggleDir() {
    this.sortDir.set(this.sortDir() === 1 ? -1 : 1);
  }
}

bootstrapApplication(List3Comp);