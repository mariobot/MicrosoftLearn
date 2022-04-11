angular.module("FinalApp",["lumx","ngRoute"])
    .config(function($routeProvider,$locationProvider){
        $locationProvider.hashPrefix('');
        $routeProvider
            .when("/",{
                controller : "MainController",
                templateUrl: "templates/home.html"
            })
            .when("/repo/:name",{
                controller: "RepoController",
                templateUrl: "templates/repo.html"
            })
            .otherwise("/")
    })