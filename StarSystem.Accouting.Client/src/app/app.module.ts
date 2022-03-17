import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';

import { AppComponent }   from './app.component';
import { SpaceObjectComponent }   from './spaceObject/spaceObject.component';
import { SpaceObjectListComponent }   from './spaceObject/spaceObjectList/spaceObjectsList.component';

const spaceObjectRoutes: Routes=[
    {path: 'toList', component:SpaceObjectListComponent}
];

const appRoutes: Routes = [
    {path: 'spaceObject', component:SpaceObjectComponent, children:spaceObjectRoutes}
];


@NgModule({
    imports:      [ BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [ AppComponent, SpaceObjectListComponent, SpaceObjectComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }