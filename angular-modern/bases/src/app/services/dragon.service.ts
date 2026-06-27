import { effect, Injectable, signal } from '@angular/core';
import { Character } from '../interfaces/character.interface';

const loadFromLocalStorage = (): Character[] => {
  const chatacters = localStorage.getItem('characters');
  return chatacters ? JSON.parse(chatacters) : [];
}

@Injectable({
  providedIn: 'root',
})
export class DragonService {

  characters = signal<Character[]>(loadFromLocalStorage())

  saveToLocalStorage = effect(() => {
    localStorage.setItem('characters', JSON.stringify(this.characters()))
  })

  addCharacter(character: Character) {
    this.characters.update((list) => [...list, character])
  }
}
