angular.module("FinalApp",["lumx","ngRoute","ngResource"])
    .config(function($routeProvider,$locationProvider){
        $locationProvider.hashPrefix('');
        $routeProvider
            .when("/",{
                controller : "MainController",
                templateUrl: "templates/home.html"
            })
            .when("/post/:id",{
                controller: "PostController",
                templateUrl: "templates/post.html"
            })
            .when("/posts/new",{
                controller: "NewPostController",
                templateUrl: "templates/post_form.html"
            })
            .when("/posts/edit/:id",{
                controller: "PostController",
                templateUrl: "templates/post_form.html"
            })
            .otherwise("/")
    })