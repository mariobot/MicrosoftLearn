angular.module("FinalApp")
.controller("MainController", function($scope,$resource){
   Post = $resource("https://jsonplaceholder.typicode.com/posts/:id",{id: "@id"});
   User = $resource("https://jsonplaceholder.typicode.com/users/:id",{id: "@id"});

   $scope.posts = Post.query();
   $scope.users = User.query();
   // query() -> GET /posts -> Un arreglo de posts -< is Array = true
})
.controller("RepoController", function($scope, $http, $routeParams){
    
})