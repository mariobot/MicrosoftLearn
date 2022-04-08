var app = angular.module("MyFirstApp",[])
.run(function($rootScope){
    $rootScope.nombre = "Mario Botero"
})
.controller("FirstController", function($scope,$rootScope){
    $scope.nombre = "Angular";
})
.controller("ChildController", function($scope){

});