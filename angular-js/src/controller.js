var app = angular.module("CustomDirective",[]).
controller("AppController", function($scope,$http){
    $http.get("https://api.github.com/users/mariobot/repos")
    .then(function(data){
        $scope.repos = data.data;
        console.log(data.data);
    },function(error){
        console.log(error);
    })
});