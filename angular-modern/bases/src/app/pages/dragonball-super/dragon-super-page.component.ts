import { Component, inject, signal } from "@angular/core";
import { CharacterListComponent } from "../../components/dragonball/character-list/character-list"
import { CharacterAppComponent } from "../../components/dragonball/character-add/character-add";
import { DragonService } from "../../services/dragon.service";

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
    
    //constructor(public dragonService: DragonService) {
    //    
    //} 

    public dragonService = inject(DragonService)

    
    

    
}