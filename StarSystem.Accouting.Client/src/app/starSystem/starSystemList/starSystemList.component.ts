import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import {StarSystemService} from '../../services/starSystem.service';
import {StarSystem} from '../models/starSystem.model';

@Component({
    selector: 'starSystemList-comp',
    templateUrl: './starSystemList.html',
    providers: [StarSystemService] 
})
export class StarSystemListComponent implements OnInit { 
    constructor(private starSystemService: StarSystemService){}
    starSystems: StarSystem[] = [];

    ngOnInit(){
        console.log("GGWP");
       this.starSystemService.getAll().subscribe((data:any)=> this.starSystems = data);
       console.log("name:" + this.starSystems[0].name);
    }
    deleteHandler(id: Guid){
        this.starSystemService.delete(id);
    }
}