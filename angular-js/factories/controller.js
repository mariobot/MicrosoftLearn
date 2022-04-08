var app = angular.module("TodoList",["LocalStorageModule"])
.factory("TodoService",function(localStorageService){
    var todoService = {};

    todoService.key = "angular-todolist";

    if(localStorageService.get(todoService.key))
    {
        todoService.activities = localStorageService.get(todoService.key)    
    }
    else
    {
        todoService.activities = [];
    }

    todoService.add = function(newActivity){
        todoService.activities.push(newActivity);
        todoService.updateLocalStorage();
    };

    todoService.updateLocalStorage = function(){
        localStorageService.set(todoService.key,todoService.activities);
    };

    todoService.clearActivities = function(){
        todoService.activities = [];
        todoService.updateLocalStorage();
    };

    todoService.getAll = function(){
        return todoService.activities;
    };

    todoService.remove = function(item){
        todoService.activities = todoService.activities.filter(function(activity){
            return activity !== item
        });
        todoService.updateLocalStorage();
        return todoService.getAll();
    };

    return todoService;
})
.controller("TodoController", function($scope,TodoService){

    $scope.todo = TodoService.getAll();
    $scope.newActivity = {};

    $scope.addActivity = function(){
       TodoService.add($scope.newActivity);
       $scope.newActivity = {};
    }
    $scope.removeActivity = function(item){
        $scope.todo = TodoService.remove(item);
    }
    $scope.clear = function(){
        TodoService.clearActivities();
        $scope.todo = TodoService.getAll();
    }
});