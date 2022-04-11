angular.module("CustomDirective",["ngRoute"])
    .config(function($routeProvider,$locationProvider){
        $locationProvider.hashPrefix('');
        $routeProvider
            .when("/",{
                controller : "ReposController",
                templateUrl: "templates/home.html"
            })
            .when("/repo/:name",{
                controller: "RepoController",
                templateUrl: "templates/repo.html"
            })
            .otherwise("/")
    })