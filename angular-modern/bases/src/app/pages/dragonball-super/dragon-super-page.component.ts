import { Component, signal } from "@angular/core";
import { CharacterListComponent } from "../../components/dragonball/character-list/character-list"
import { CharacterAppComponent } from "../../components/dragonball/character-add/character-add";

interface Character {
    id: number;
    name: string;
    power: number;
}

@Component({
    selector: "dragon-super",
    templateUrl: './dragon-super-page.component.html',
    imports: [CharacterListComponent, CharacterAppComponent]    
})

export class DragonSuperPageComponent {

    name = signal('');
    power = signal(0);

    characters = signal<Character[]>([
        { id: 1, name: 'Goku', power: 15000 },
        { id: 2, name: 'Vegeta', power: 7500 },
    ])

    
}