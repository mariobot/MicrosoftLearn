angular.module("CustomDirective")
.controller("ReposController", function($scope,$http){
    $scope.repos = [];

    $http.get("https://api.github.com/users/mariobot/repos")
    .then(function(data){
        $scope.posts = data.data;
        for (let i = data.data.length - 1; i >= 0; i-- )
        {
            var repo = data.data[i];
            $scope.repos.push(repo.name);
        } 
    },function(error){
        console.log(error);
    })

    $scope.optionSelected = function(data)
    {
        $scope.$apply(function(){
            $scope.main_repo = data
        })
    }
})
.controller("RepoController", function($scope, $http, $routeParams){
    $scope.repo = {};
    $http.get("https://api.github.com/repos/mariobot/"+$routeParams.name)
    .then(function(data){
        $scope.repo = data.data
    },function(error){
        console.log(error);
    })
})