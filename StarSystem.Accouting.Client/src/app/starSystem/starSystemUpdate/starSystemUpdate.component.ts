import {Component} from '@angular/core';
import {StarSystem} from '../models/starSystem.model';
import {SpaceObject} from '../../spaceObject/models/spaceObject.model';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import {Data, StarSystemService} from '../../services/starSystem.service';
import { SpaceObjectService } from 'src/app/services/spaceObject.service';
import {ErrorHandlerService} from '../../services/errorHandler.service';
import { NgForm } from '@angular/forms';
import { StarSystemUpdateRequest } from '../models/starSystemUpdateRequest.model';
import { takeLast } from 'rxjs';
import { compileFunction } from 'vm';
@Component({
 selector:'starSystemUpdate-comp',
 templateUrl:'./starSystemUpdate.html',
 providers:[StarSystemService, SpaceObjectService, ErrorHandlerService]
})
export class StarSystemUpdateComponent{
    starSystem: StarSystem = new StarSystem();
    starSystemId:Guid = Guid.createEmpty();
    spaceObjectsByStarSystem: SpaceObject[] = [];
    spaceObjectid: Guid = Guid.createEmpty();
    currentCenterOfGravity: string = "";

    constructor(private activatedRoute: ActivatedRoute, public starSystemService: StarSystemService, public spaceObjectService: SpaceObjectService){
        this.starSystemId = activatedRoute.snapshot.params['id'];
        
    }

    ngOnInit(){
        this.starSystemService.getById(this.starSystemId).subscribe((data:any)=>{this.starSystem = data; this.currentCenterOfGravity=this.starSystem.centerOfGravityName;});
        this.spaceObjectService.getAllByStarSystemId(this.starSystemId).subscribe((data:any)=>this.spaceObjectsByStarSystem = data);
        this.spaceObjectsByStarSystem = this.spaceObjectsByStarSystem.filter(s=>s.type=="Завезда" || s.type=="Черная дыра");
    }

    submit(myForm: NgForm){
        
        this.spaceObjectid = this.spaceObjectsByStarSystem.filter(sobj=>sobj.name == this.starSystem.centerOfGravityName)[0].id;
        this.starSystemService.update(new StarSystemUpdateRequest( this.starSystemId, myForm.value.name, myForm.value.age), this.starSystemId, this.spaceObjectid);
    }
}