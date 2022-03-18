import { Guid } from "guid-typescript";
export class SpaceObjectCreateRequest{
    constructor(public name: string, public type: string, public age: number, public diameter: number, public weight: number, public starSystemId: Guid)
    {
        this._age = age;
        this._name = name;
        this._diameter = diameter;
        this._type = type;
        this._weight = weight;
        this._starSystemId = starSystemId;

    }

    public _name: string;
    public _type: string;
    public _age: number;
    public _diameter: number;
    public _weight: number;
    public _starSystemId: Guid;

}