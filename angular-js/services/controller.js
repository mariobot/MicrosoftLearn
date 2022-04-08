var app = angular.module("TodoList",["LocalStorageModule"])
.service("TodoService",function(localStorageService){    

    this.key = "angular-todolist";

    if(localStorageService.get(this.key))
    {
        this.activities = localStorageService.get(this.key)    
    }
    else
    {
        this.activities = [];
    }

    this.add = function(newActivity){
        this.activities.push(newActivity);
        this.updateLocalStorage();
    };

    this.updateLocalStorage = function(){
        localStorageService.set(this.key,this.activities);
    };

    this.clearActivities = function(){
        this.activities = [];
        this.updateLocalStorage();
    };

    this.getAll = function(){
        return this.activities;
    };

    this.remove = function(item){
        this.activities = this.activities.filter(function(activity){
            return activity !== item
        });
        this.updateLocalStorage();
        return this.getAll();
    };

    return this;
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