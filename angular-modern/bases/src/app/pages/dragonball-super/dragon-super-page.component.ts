import { Component, signal } from "@angular/core";
import { CharacterListComponent } from "../../components/dragonball/character-list/character-list"

interface Character {
    id: number;
    name: string;
    power: number;
}

@Component({
    selector: "dragon-super",
    templateUrl: './dragon-super-page.component.html',
    imports: [CharacterListComponent]    
})

export class DragonSuperPageComponent {

    name = signal('');
    power = signal(0);

    characters = signal<Character[]>([
        { id: 1, name: 'Goku', power: 15000 },
        { id: 2, name: 'Vegeta', power: 7500 },
    ])

    addCharacter() {
        if(!this.name() || !this.power() || this.power() <= 0) return;
        
        const newCharacter: Character = {
            id: this.characters().length + 1,
            name: this.name(),
            power: this.power()
        }

        this.characters.update((list) => [...list, newCharacter])
        
        //console.log(this.name() + this.power())
        this.resetFields()
    }

    resetFields() {
        this.name.set('');
        this.power.set(0);
    }
}