import {Component, OnInit} from '@angular/core'
import {SpaceObjectService} from '../../services/spaceObject.service'
import {SpaceObjectCreate} from '../models/spaceObjectCreate.model';
import {SpaceObjectCreateRequest} from '../models/spaceObjectCreateRequest.model';
import {StarSystem} from '../../starSystem/models/starSystem.model'
import { Guid } from "guid-typescript";
import { NgForm } from '@angular/forms';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SpaceObjectUpdate } from '../models/SpaceObjectUpdate.model';
import { ActivatedRoute} from '@angular/router';


@Component({
    selector:'spaceObjectCreate-comp',
    templateUrl: './spaceObjectUpdate.html',
    providers:[SpaceObjectService]
})

export class SpaceObjectUpdateComponent implements OnInit{
    spaceObject: SpaceObjectCreate = new SpaceObjectCreate();
    id:Guid = Guid.createEmpty();
    
    constructor(private spaceObjectService: SpaceObjectService, private activateRoute: ActivatedRoute){
        this.id = activateRoute.snapshot.params['id'];
        console.log(this.id);
    }

   
    submit(myForm: NgForm){
        this.spaceObjectService.update(new SpaceObjectUpdate(this.id, myForm.value.name, myForm.value.type,myForm.value.age, myForm.value.weight, myForm.value.diameter));
    }

    ngOnInit(){
        this.spaceObjectService.getById(this.id).subscribe((data:any)=> this.spaceObject = data);

    }
}