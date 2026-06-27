import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { Character } from '../../../interfaces/character.interface';

@Component({
  selector: 'dragon-character-add',
  imports: [],
  templateUrl: './character-add.html',
})

export class CharacterAppComponent {
  name = signal('')
  power = signal(0)
  
  addCharacter() {
        if(!this.name() || !this.power() || this.power() <= 0) return;
        
        const newCharacter: Character = {
            id: 1000,
            name: this.name(),
            power: this.power()
        }

        //this.characters.update((list) => [...list, newCharacter])
        
        console.log(this.name() + this.power())
        this.resetFields()
    }

    resetFields() {
        this.name.set('');
        this.power.set(0);
    }
}
