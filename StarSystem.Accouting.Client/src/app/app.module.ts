import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule }   from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {Routes, RouterModule} from '@angular/router';
import { AppComponent }   from './app.component';
import { SpaceObjectComponent }   from './spaceObject/spaceObject.component';
import { SpaceObjectListComponent }   from './spaceObject/spaceObjectList/spaceObjectsList.component';
import {SpaceObjectCreateComponent} from './spaceObject/SpaceObjectCreate/spaceObjectCreate.component';
import {SpaceObjectUpdateComponent} from './spaceObject/SpaceObjectUpdate/spaceObjectUpdate.component';
import {StarSystemListComponent} from './starSystem/starSystemList/starSystemList.component';
import {StarSystemComponent} from './starSystem/starSystem.component';
import {StarSystemUpdateComponent} from './starSystem/starSystemUpdate/starSystemUpdate.component';
import {StarSystemCreateComponent} from './starSystem/starSystemCreate/starSystemCreate.component';



const spaceObjectRoutes: Routes=[
    {path: 'toList', component:SpaceObjectListComponent},
    {path: 'create', component:SpaceObjectCreateComponent},
    {path: 'toList/update/:id', component:SpaceObjectUpdateComponent}
];
const starSystemRoutes: Routes=[
    {path: 'toList', component:StarSystemListComponent},
    {path: 'toList/update/:id', component: StarSystemUpdateComponent},
    {path: 'create', component: StarSystemCreateComponent}
];

const appRoutes: Routes = [
    {path: 'spaceObject', component:SpaceObjectComponent, children:spaceObjectRoutes},
    {path: 'starSystem', component:StarSystemComponent, children:starSystemRoutes}
];




@NgModule({
    imports:      [ BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes)],
    declarations: [ AppComponent, SpaceObjectListComponent, SpaceObjectComponent, SpaceObjectCreateComponent, SpaceObjectUpdateComponent,
    StarSystemComponent, StarSystemListComponent, StarSystemUpdateComponent, StarSystemCreateComponent ],
    bootstrap:    [ AppComponent ]
})
export class AppModule { }