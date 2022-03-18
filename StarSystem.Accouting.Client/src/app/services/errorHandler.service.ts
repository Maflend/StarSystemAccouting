import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Guid } from "guid-typescript";

@Injectable()
export class ErrorHandlerService {
    errorMessage: string = "";
    
    constructor(){}


    public handleError = (error: HttpErrorResponse) => {
        if(error.status === 400){
          this.handle400Error(error);
        }
        else{
            console.log("other");
        }
      }

      private handle400Error = (error: HttpErrorResponse) => {
        this.createErrorMessage(error);
      }

      private createErrorMessage = (error: HttpErrorResponse) => {
        this.errorMessage = error.error ? error.error : error.statusText;
      }
}