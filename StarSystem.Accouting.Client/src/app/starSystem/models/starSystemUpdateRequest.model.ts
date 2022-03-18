import { Guid } from "guid-typescript";

export class StarSystemUpdateRequest{
    constructor(id: Guid, name: string, age: number){
        this.id = id;
        this.name = name;
        this.age = age;
    }
    public id: Guid = Guid.createEmpty();
    public name: string = "";
    public age: number = 0;
}
