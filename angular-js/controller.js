var app = angular.module("MyFirstApp",[]);
app.controller("FirstController", function($scope){
    $scope.nombre ="MaRioBot";
    $scope.nuevoComentario = {};
    $scope.comentarios = [{
        comentario: "Bn tutorial",
        username: "tester1"
    },{
        comentario: "Mal tutorial",
        username: "tester2"
    }];
    $scope.agregarComentario = function(){
        $scope.comentarios.push($scope.nuevoComentario);
        $scope.nuevoComentario = {};
    }
});