console.log("Hi world TypeScript");
//types
var miVariable = "Hola mundo";
miVariable = 22 + "";
var miNumber = 22;
var miBool = true;
var miVariable2 = "hello";
miVariable2 = 22;
// Arrays
var StringArray = ["ho", "la"];
var NumberArray = [1, 2, 3, 4, 5];
var BooleanArray = [true, false, true];
var AnyArray = ["uno", 2, true];
//Tuples
var strTuple = ["Mario", 50];
// void, undefined, null
var myVoid = undefined;
var myNull = null;
var myUndefined = undefined;
// Functions
function getSuma(num1, num2) {
    return num1 + num2;
}
function getNamePerson(firstName, lastName) {
    return firstName + ' ' + lastName;
}
function myVoidFunction() {
}
function showTodo(todo) {
    console.log(todo.text + " " + todo.title);
}
showTodo({
    title: "Welcome to TypeScript",
    text: "Funciones con typescript"
});
var myTodo = {
    title: "Welcome to TypeScript tutorial",
    text: "Funciones con typescript tutorial"
};
showTodo(myTodo);
// Clases
document.write();
