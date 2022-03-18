import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript";
import {StarSystemUpdateRequest} from '../starSystem/models/starSystemUpdateRequest.model';
import {StarSystemCreateRequest} from '../starSystem/models/starSystemCreateRequest.model';
import {ErrorHandlerService} from './errorHandler.service';
@Injectable()
export class StarSystemService {

    errorMessage: string = "";

    constructor(private http: HttpClient, private errorHandlerService: ErrorHandlerService){}
    create(request: StarSystemCreateRequest){
        return this.http.post("https://localhost:7090/api/StarSystem/Create", request).subscribe(
            data=>{
                window.location.href="/starSystem/toList";
            },
            err=>{
                console.log("ErrorCreate:", err);
                this.errorHandlerService.handleError(err);
                this.errorMessage =  this.errorHandlerService.errorMessage;
            }
        );
    }
    getAll() {
        return this.http.get("https://localhost:7090/api/StarSystem/GetAll");
    }
    update(starSystemUpdateRequest: StarSystemUpdateRequest, starSystemId: Guid, spaceObjectId: Guid){
        return this.http.post("https://localhost:7090/api/StarSystem/Update", starSystemUpdateRequest).subscribe(
            data => {
            console.log("Обновил звездную систему с id: ", data);
            this.setCenterOfGravity(starSystemId,spaceObjectId);
            },
            err => {
            console.log("ErrorUpdate:", err);
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
    }
    getById(id:Guid){
        return this.http.get("https://localhost:7090/api/StarSystem/GetById?id=" + id);
    }
    setCenterOfGravity(starSystemId: Guid, spaceObjectId: Guid){
        var mydata = new Data(starSystemId, spaceObjectId);
      
        return this.http.post("https://localhost:7090/api/StarSystem/SetCenterOfGravity", mydata).subscribe(
            data => {
            console.log("Изменил центр: ", data);
            window.location.href = '/starSystem/toList';
            },
            err => {
            console.log("ErrorSetCenterOfGravity:", err);
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
    }
    delete(id: Guid){
        return this.http.delete("https://localhost:7090/api/StarSystem/Delete/" + id).subscribe(
            data => {
            console.log("Удалил обьект с id: ", data);
            window.location.href = '/starSystem/toList';
            },
            err => {
            console.log("ErrorDelete:", err);
            this.errorHandlerService.handleError(err);
            this.errorMessage =  this.errorHandlerService.errorMessage;
            });
    }
}

export class Data{
     constructor(StarSystemId: Guid,SpaceObjectId: Guid){
         this.SpaceObjectId = SpaceObjectId;
         this.StarSystemId = StarSystemId;
     }
    public StarSystemId: Guid;
    public SpaceObjectId: Guid;
}