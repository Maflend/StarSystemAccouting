import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import {StarSystemService} from '../../services/starSystem.service';
import {ErrorHandlerService} from '../../services/errorHandler.service';
import {StarSystem} from '../models/starSystem.model';

@Component({
    selector: 'starSystemList-comp',
    templateUrl: './starSystemList.html',
    providers: [StarSystemService, ErrorHandlerService] 
})
export class StarSystemListComponent implements OnInit { 
    constructor(public starSystemService: StarSystemService){}
    starSystems: StarSystem[] = [];

    ngOnInit(){
       this.starSystemService.getAll().subscribe((data:any)=> this.starSystems = data);
    }
    deleteHandler(id: Guid){
        this.starSystemService.delete(id);
    }
}