import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable()
export class StarSystemService {
    constructor(private http: HttpClient){}

    getAll() {
        return this.http.get("https://localhost:7090/api/StarSystem/GetAll");
    }
}