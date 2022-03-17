import {HttpClient, HttpErrorResponse} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Guid } from 'guid-typescript';
import { request } from 'http';
import { catchError, Observable } from 'rxjs';
import { SpaceObjectCreate } from '../spaceObject/spaceObjectCreate.model';
import {SpaceObjectCreateRequest} from '../spaceObject/spaceObjectCreateRequest.model';
@Injectable()
export class SpaceObjectService {
    constructor(private http: HttpClient){}
    errorMessage: string = "";
    readonly apiUrl:string = "https://localhost:7090/api/";
    getAll() {
        return this.http.get("https://localhost:7090/api/SpaceObject/GetAll");
    }
    create(spaceObjectCreate: SpaceObjectCreateRequest){
        //return this.http.post("https://localhost:7090/api/SpaceObject/Create",spaceObjectCreate).;
        return this.http.post("https://localhost:7090/api/SpaceObject/Create",spaceObjectCreate).subscribe(data => {
            console.log("Создал обьект с id: ", data);
            },
            err => {
            console.log("ErrorMY:", err);
            });
    }
    getStarSystems(){
        return this.http.get("https://localhost:7090/api/StarSystem/GetAll");
    }

}