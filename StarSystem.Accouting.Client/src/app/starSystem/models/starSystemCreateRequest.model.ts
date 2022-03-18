export class StarSystemCreateRequest{
    constructor(name:string, age:number, centerOfGravityName:string, centerOfGravityType:string,
         centerOfGravityAge:number, centerOfGravityDiameter:number, centerOfGravityWeight:number){
            this.name = name;
            this.age = age;
            this.centerOfGravityName = centerOfGravityName;
            this.centerOfGravityType = centerOfGravityType;
            this.centerOfGravityAge = centerOfGravityAge;
            this.centerOfGravityDiameter = centerOfGravityDiameter;
            this.centerOfGravityWeight = centerOfGravityWeight;
    }
    public name:string = "";
    public age:number = 0;
    public centerOfGravityName:string = "";
    public centerOfGravityType:string = "";
    public centerOfGravityAge:number = 0;
    public centerOfGravityDiameter:number = 0;
    public centerOfGravityWeight:number = 0;
}