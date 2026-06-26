import { Component, signal } from "@angular/core";

interface Character {
    id: number;
    name: string;
    power: number;
}

@Component({
    templateUrl: './dragon-page.component.html',    
})

export class DragonPageComponent {

    characters = signal<Character[]>([
        { id: 1, name: 'Goku', power: 15000 },
        { id: 2, name: 'Vegeta', power: 7500 },
        { id: 3, name: 'Trunks', power: 5000 },
        { id: 4, name: 'Yamcha', power: 500 },
    ])
}