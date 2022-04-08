var app = angular.module("CustomDirective",[])
.directive("backImg",function(){
    return function(scope, element, attrs){
        attrs.$observe("backImg",function(value){
            element.css({
                "background": "url("+value+")",
                "background-size": "cover",
                "background-position": "center"
            });
        });
    }
})
.controller("AppController", function($scope,$http){
    $http.get("https://api.github.com/users/mariobot/repos")
    .then(function(data){
        $scope.repos = data.data;
        console.log(data.data);
    },function(error){
        console.log(error);
    })
});