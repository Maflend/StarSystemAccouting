import {Component, OnInit} from '@angular/core'
import { NgForm } from '@angular/forms';
import { Guid } from 'guid-typescript';
import {SpaceObjectService} from '../../services/spaceObject.service'
import {SpaceObject} from '../spaceObject.model';
import { SpaceObjectUpdate } from '../SpaceObjectUpdate.model';

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

    deleteHandler(id:Guid){
        this.spaceObjectService.delete(id);
    }
    updateHandler(id:Guid){
        //this.spaceObjectService.update(new SpaceObjectUpdate(myForm.value.id, myForm.value.name, myForm.value.age, myForm.value.type, myForm.value.weight, myForm.value.diameter));
        
    }
}