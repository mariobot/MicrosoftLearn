var app = angular.module("TodoList",["LocalStorageModule"]).
controller("TodoController", function($scope,localStorageService){
    if(localStorageService.get("angular-todolist"))
    {
        $scope.todo = localStorageService.get("angular-todolist")    
    }
    else
    {
        $scope.todo = [];
    }   
    
    $scope.newActivity = {};    
    $scope.addActivity = function(){
       $scope.todo.push($scope.newActivity);
       $scope.newActivity = {};
       localStorageService.set("angular-todolist", $scope.todo);
    }
    $scope.clear = function(){
        $scope.todo = [];
        localStorageService.set("angular-todolist", $scope.todo);
    }
});