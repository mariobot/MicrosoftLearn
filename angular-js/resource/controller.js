angular.module("FinalApp")
.controller("MainController", function($scope,$resource){
   Post = $resource("https://jsonplaceholder.typicode.com/posts/:id",{id: "@id"});
   User = $resource("https://jsonplaceholder.typicode.com/users/:id",{id: "@id"});

   $scope.posts = Post.query();
   $scope.users = User.query();
   // query() -> GET /posts -> Un arreglo de posts -< is Array = true

   $scope.removePost = function(post){
      Post.delete({id: post.id});
      $scope.posts = $scope.posts.filter(function(element){
         return element.id !== post.id;
      });
   }
})
.controller("PostController", function($scope, $resource, $routeParams){
   Post = $resource("https://jsonplaceholder.typicode.com/posts/:id",{id: "@id"});
   $scope.post = Post.get({id: $routeParams.id});
})