var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
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
var User = /** @class */ (function () {
    function User(name, email, age) {
        this.name = name;
        this.email = email;
        this.age = age;
    }
    User.prototype.register = function () {
        console.log(this.name + " was registered");
    };
    User.prototype.showAge = function () {
        return this.age;
    };
    User.prototype.ageInYears = function () {
        return this.age + "years";
    };
    return User;
}());
var mario = new User("Mario Botero", "mariobot@mail.com", 30);
// Herencia
var members = /** @class */ (function (_super) {
    __extends(members, _super);
    function members(id, name, email, age) {
        var _this = _super.call(this, name, email, age) || this;
        _this.id = id;
        return _this;
    }
    members.prototype.ageInYears2 = function () {
        _super.prototype.ageInYears.call(this);
    };
    return members;
}(User));
var mario2 = new members(2, "Mario Botero", "mariobot@mail.com", 30);
document.write();
