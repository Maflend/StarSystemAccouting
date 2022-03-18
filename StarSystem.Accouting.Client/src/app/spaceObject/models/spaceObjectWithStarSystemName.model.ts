import { Guid } from "guid-typescript";
export class spaceObjectWithStarSystemName{
    
    public id: Guid = Guid.createEmpty();
    public name: string = "";
    public type: string = "";
    public age: number = 0;
    public diameter: number = 0;
    public weight: number = 0;
    public starSystemName: string = "";

}