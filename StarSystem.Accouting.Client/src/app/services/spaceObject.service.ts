import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class SpaceObjectService{
    constructor(private http: HttpClient){}
    readonly apiUrl:string = "https://localhost:7090/api/";
    getAll() {
        return this.http.get("https://localhost:7090/api/SpaceObject/GetAll");
    }
}