import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';

import { AppComponent }   from './app.component';
import { SpaceObjectListComponent }   from './spaceObject/spaceObjectList/spaceObjectsList.component';


const appRoutes: Routes = [
    {path: 'spaceObjects', component:SpaceObjectListComponent}
];


@NgModule({
    imports:      [ BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [ AppComponent, SpaceObjectListComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }