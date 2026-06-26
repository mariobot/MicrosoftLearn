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

    name = signal('Gohan');
    power = signal(1000);

    characters = signal<Character[]>([
        { id: 1, name: 'Goku', power: 15000 },
        { id: 2, name: 'Vegeta', power: 7500 },
        { id: 3, name: 'Trunks', power: 5000 },
        { id: 4, name: 'Yamcha', power: 500 },
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