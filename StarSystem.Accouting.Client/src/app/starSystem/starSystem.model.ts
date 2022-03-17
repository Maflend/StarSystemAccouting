import { Guid } from "guid-typescript";

export class StarSystem{
    public id: Guid = Guid.createEmpty();
    public name: string = "";
    public age: number = 0;
    public centerOfGravityName:string = "";
}
