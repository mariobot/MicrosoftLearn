"use strict";

angular.module('app').directive("wwaDashboard",[function(){
    return {
        scope:{

        },
        template: "<ps-dashboard></ps-dashboard>",
        link: function(scope){

            scope.title = "My first Dashboard";

            scope.gridsterOpts = {
                columns: 12,
                margins: [20,20],
                outerMargin: false,
                pushing: true,
                floating: true,
                swapping: false
            };

            scope.widgets = [
                {
                    title: "First",
                    sizeX: 3,
                    sizeY: 3,
                    row: 0,
                    col: 0
                },
                {
                    title: "Second",
                    sizeX: 2,
                    sizeY: 3,
                    row: 0,
                    col: 5
                }
            ]
        }
    }
}]);