import { Component, input } from '@angular/core';
import type { Character } from '../../../interfaces/character.interface';

@Component({
  selector: 'dragon-character-list',
  imports: [],
  templateUrl: './character-list.html',
})
export class CharacterListComponent {
  characters = input.required<Character[]>()
}
