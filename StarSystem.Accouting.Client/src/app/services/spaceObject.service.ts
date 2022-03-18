import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { request } from 'http';
import { catchError, Observable } from 'rxjs';
import { SpaceObjectCreate } from '../spaceObject/models/spaceObjectCreate.model';
import {SpaceObjectCreateRequest} from '../spaceObject/models/spaceObjectCreateRequest.model';
import {SpaceObjectUpdate} from '../spaceObject/models/SpaceObjectUpdate.model';
import {ErrorHandlerService} from './errorHandler.service';
@Injectable()
export class SpaceObjectService {
    constructor(private http: HttpClient, private errorHandlerService: ErrorHandlerService){}
  
    readonly apiUrl:string = "https://localhost:7090/api/";


    errorMessage: string = "";
   


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
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
            
    }
    getAllByStarSystemId(id: Guid){
        return this.http.get("https://localhost:7090/api/SpaceObject/GetAllByStarSystemId?StarSystemId=" + id);
    }
    delete(id:Guid){
        return this.http.delete("https://localhost:7090/api/SpaceObject/Delete/"+ id).subscribe(
            data => {
            console.log("Удалил обьект с id: ", data);
            window.location.href = '/spaceObject/toList';
            },
            err => {
            console.log("ErrorDelete:", err);
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
    }
    update(spaceObj:SpaceObjectUpdate){
        console.log("id:" + spaceObj.id + "|| name:" + spaceObj.name);
        console.log("type:" + spaceObj.type + "|| weight:" + spaceObj.weight);
        console.log("diameter:" + spaceObj.diameter + "|| age:" + spaceObj.name);
        return this.http.post("https://localhost:7090/api/SpaceObject/Update", spaceObj).subscribe(
            data => {
            console.log("Обновил обьект с id: ", data);
            window.location.href = '/spaceObject/toList';
            },
            err => {
            console.log("ErrorUpdate:", err);
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
    }






    

}