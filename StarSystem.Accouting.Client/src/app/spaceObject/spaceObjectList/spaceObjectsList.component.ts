import {Component, OnInit} from '@angular/core'
import { NgForm } from '@angular/forms';
import { Guid } from 'guid-typescript';
import {SpaceObjectService} from '../../services/spaceObject.service'
import {SpaceObject} from '../models/spaceObject.model';
import { SpaceObjectUpdate } from '../models/SpaceObjectUpdate.model';

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
}