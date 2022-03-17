import {Component, OnInit} from '@angular/core'
import {SpaceObjectService} from '../../services/spaceObject.service'
import {SpaceObject} from '../spaceObject.model';

@Component({
    selector:'spaceObjectsList-comp',
    templateUrl:'./spaceObjectsList.html',
    providers: [SpaceObjectService]
})

export class SpaceObjectListComponent implements OnInit{
    SpaceObjects: SpaceObject[] = []; 
    constructor(private spaceObjectService: SpaceObjectService){}
    ngOnInit(){
        this.spaceObjectService.getAll().subscribe((data:any)=> this.SpaceObjects = data);
        
    }
}