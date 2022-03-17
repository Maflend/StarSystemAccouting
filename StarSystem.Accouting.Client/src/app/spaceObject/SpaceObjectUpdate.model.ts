import { Guid } from "guid-typescript";

export class SpaceObjectUpdate{
    constructor(public _id:Guid,public _name: string, public _type: string, public _age: number, public _diameter: number, public _weight: number)
    {
        this.id = _id;
        this.age = _age;
        this.name = _name;
        this.diameter = _diameter;
        this.type = _type;
        this.weight = _weight;
    }
    public id: Guid = Guid.createEmpty();
    public name: string = "";
    public type: string = "";
    public age: number = 0;
    public diameter: number = 0;
    public weight: number = 0;
}