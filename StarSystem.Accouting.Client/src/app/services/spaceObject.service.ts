import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { request } from 'http';
import { catchError, Observable } from 'rxjs';
import { SpaceObjectCreate } from '../spaceObject/spaceObjectCreate.model';
import {SpaceObjectCreateRequest} from '../spaceObject/spaceObjectCreateRequest.model';
import {SpaceObjectUpdate} from '../spaceObject/SpaceObjectUpdate.model';
@Injectable()
export class SpaceObjectService {
    constructor(private http: HttpClient){}
    errorMessage: string = "";
    readonly apiUrl:string = "https://localhost:7090/api/";
    getAll() {
        return this.http.get("https://localhost:7090/api/SpaceObject/GetAll");
    }
    getById(id: Guid){
        return this.http.get("https://localhost:7090/api/SpaceObject/GetById?id="+ id);
    }
    create(spaceObjectCreate: SpaceObjectCreateRequest){
        return this.http.post("https://localhost:7090/api/SpaceObject/Create",spaceObjectCreate).subscribe(
            data => {
            console.log("Создал обьект с id: ", data);
            window.location.href = '/spaceObject/toList';
            },
            err => {
            console.log("ErrorCreate:", err);
            
            });
            
    }
    getStarSystems(){
        return this.http.get("https://localhost:7090/api/StarSystem/GetAll");
    }
    delete(id:Guid){
        return this.http.delete("https://localhost:7090/api/SpaceObject/Delete/"+ id).subscribe(
            data => {
            console.log("Удалил обьект с id: ", data);
            window.location.href = '/spaceObject/toList';
            },
            err => {
            console.log("ErrorDelete:", err);
            });
    }
    update(spaceObj:SpaceObjectUpdate){
        console.log("id:" + spaceObj.id + "|| name:" + spaceObj.name);
        console.log("type:" + spaceObj.type + "|| weight:" + spaceObj.weight);
        console.log("diameter:" + spaceObj.diameter + "|| age:" + spaceObj.age);
        return this.http.post("https://localhost:7090/api/SpaceObject/Update", spaceObj).subscribe(
            data => {
            console.log("Обновил обьект с id: ", data);
            window.location.href = '/spaceObject/toList';
            },
            err => {
            console.log("ErrorUpdate:", err);
            });
    }

}