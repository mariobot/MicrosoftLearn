var app = angular.module("mainModule",[])
    .filter("removeHtml", function(){
        return function(texto){
            return String(texto).replace(/<[^>]+>/gm,'');
        };
    })
    .controller("FiltersController", function($scope){
        $scope.mi_html = "<p>Hola mundo</p>";
        $scope.costo = 2
    });

    