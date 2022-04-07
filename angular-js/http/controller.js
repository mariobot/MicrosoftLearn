var app = angular.module("MyFirstApp",[]).
controller("FirstController", function($scope,$http){
    $scope.posts = [];
    $scope.newPost = {};
    $http.get("http://jsonplaceholder.typicode.com/posts")
    .then(function (response){
        console.log(response);
        $scope.posts = response.data;
    },function (error){
        console.log(error);
    });

    $scope.addPost = function(){
        $http.post("http://jsonplaceholder.typicode.com/posts",{
            title: $scope.newPost.title,
            body: $scope.newPost.body,
            userId: 1
        })
        .then(function (data,status,headers,config){
            $scope.posts.push(data.data);
            $scope.newPost = {};
        },function (error,status,headers,config){
            console.log(error);
        });
    }
});