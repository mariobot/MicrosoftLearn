console.log("Hi world TypeScript");
//types
var miVariable : string = "Hola mundo";
miVariable = 22 + "";

var miNumber : number = 22;

var miBool : boolean = true;

var miVariable2 : any = "hello"
miVariable2 = 22;

// Arrays
var StringArray : string[] = ["ho","la"];
var NumberArray : number[] = [1,2,3,4,5];
var BooleanArray : boolean[] = [true, false, true];
var AnyArray: any[] = ["uno",2,true]

//Tuples
var strTuple : [string,number] = ["Mario",50];

// void, undefined, null
let myVoid : void = undefined;
let myNull : null = null;
let myUndefined : undefined = undefined;

// Functions
function getSuma(num1: number, num2: number): number {
    return num1 + num2;
}

function getNamePerson(firstName: string, lastName? : string):string{
    return firstName + ' ' + lastName;
}

function myVoidFunction():void
{

}

// Interface
interface ITodo{
    title: string;
    text: string;
}

function showTodo(todo: ITodo){
    console.log(`${todo.text} ${todo.title}`)
} 

showTodo({
    title:"Welcome to TypeScript",
    text:"Funciones con typescript"
})

let myTodo: ITodo = {
    title: "Welcome to TypeScript tutorial",
    text: "Funciones con typescript tutorial"
}
showTodo(myTodo)

// Clases

class User{
    private name: string;
    public email: string;
    private age: number;

    constructor(name: string, email: string, age :number){
        this.name = name;
        this.email = email;
        this.age = age;
    }

    register(){
        console.log(`${this.name} was registered`);
    }

    showAge(){
        return this.age;
    }

    public ageInYears()
    {
        return this.age + "years";
    }
}

var mario = new User("Mario Botero","mariobot@mail.com",30);

// Herencia
class members extends User{
    id:number;

    constructor(id, name, email, age){
        super(name,email,age);
        this.id = id;
    }

    ageInYears2(){
        super.ageInYears();
    }
}


var mario2 = new members(2,"Mario Botero", "mariobot@mail.com", 30);

document.write();


