import {Component} from '@angular/core';
import { NgForm } from '@angular/forms';
import {StarSystemService} from '../../services/starSystem.service';
import {ErrorHandlerService} from '../../services/errorHandler.service';
import { StarSystemCreateRequest } from '../models/starSystemCreateRequest.model';
import { StarSystemCreate} from '../models/starSystemCreate.model';
@Component({
    selector:"starSystemCreate-comp",
    templateUrl: './starSystemCreate.html',
    providers: [StarSystemService, ErrorHandlerService]
})

export class StarSystemCreateComponent{

    starSystemCreate: StarSystemCreate = new StarSystemCreate();

    constructor(public starSystemService: StarSystemService){}

    ngOnInit(){
    }

    submit(myForm: NgForm){
        this.starSystemService.create(new StarSystemCreateRequest(myForm.value.name, myForm.value.age, myForm.value.centerOfGravityName,
            myForm.value.centerOfGravityType, myForm.value.centerOfGravityAge, myForm.value.centerOfGravityDiameter, myForm.value.centerOfGravityWeight));
    }
}