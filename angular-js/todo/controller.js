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
    $scope.$watchCollection('todo', function(newValue,oldValue){
        localStorageService.set("angular-todolist",$scope.todo);
    });    
    $scope.addActivity = function(){
       $scope.todo.push($scope.newActivity);
       $scope.newActivity = {};
    }
    $scope.clear = function(){
        $scope.todo = [];
    }
});