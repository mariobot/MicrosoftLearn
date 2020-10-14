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



document.write();


