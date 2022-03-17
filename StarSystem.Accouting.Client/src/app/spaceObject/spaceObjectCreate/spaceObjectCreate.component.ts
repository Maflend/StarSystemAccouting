import {Component, OnInit} from '@angular/core'
import {SpaceObjectService} from '../../services/spaceObject.service'
import {SpaceObjectCreate} from '../spaceObjectCreate.model';
import {SpaceObjectCreateRequest} from '../spaceObjectCreateRequest.model';
import {StarSystem} from '../../starSystem/starSystem.model'
import { Guid } from "guid-typescript";
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';



@Component({
    selector:'spaceObjectCreate-comp',
    templateUrl: './spaceObjectCreate.html',
    providers:[SpaceObjectService]
})

export class SpaceObjectCreateComponent implements OnInit{
    spaceObject: SpaceObjectCreate = new SpaceObjectCreate();
    starSystem: StarSystem[] = [];
    
    constructor(private spaceObjectService: SpaceObjectService){}

    id: Guid = Guid.createEmpty();
   
    submit(myForm: NgForm){
        this.id = this.starSystem.filter(s=>s.name == myForm.value.starSystemName)[0].id;
        this.spaceObjectService.create(new SpaceObjectCreateRequest( myForm.value.name,
            myForm.value.type, myForm.value.age, myForm.value.diameter, myForm.value.weight, this.id));
    }
   
    ngOnInit(){
      this.spaceObjectService.getStarSystems().subscribe((data:any)=>this.starSystem = data);
    }
}