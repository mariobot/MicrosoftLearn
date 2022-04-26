"use strict";

angular.module('app').directive("wwaDashboard",["$localStorage",function($localStorage){
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

            scope.widgetDefinitions = [
                {
                    title: 'Temperature',
                    settings:{
                        sizeX: 3,
                        sizeY: 3,
                        minSizeX: 2,
                        minSizeY: 2,                        
                        template: "<wwa-temperature></wwa-temperature>",
                        widgetSettings:{
                            id: 1000,
                            templateUrl: 'app/dialogs/wwaSelectLocationTemplate.html',
                            controller: 'wwaSelectLocationController'
                        }
                    }
                },
                {
                    title: 'Employee',
                    settings:{
                        sizeX: 5,
                        sizeY: 3,
                        template: "<wwa-employee></wwa-employee>",
                        widgetSettings:{
                            id: 5001,
                            templateUrl: 'app/dialogs/wwaSelectEmployeeTemplate.html',
                            controller: 'wwaSelectEmployeeController'
                        }
                    }
                },
                {
                    title: "Inventory",
                    settings:{
                        sizeX: 5,
                        sizeY: 3,
                        row: 3,
                        col: 5,
                        template: "<wwa-inventory></wwa-inventory>",
                        widgetSettings:{
                            id: 1002,
                            templateUrl: 'app/dialogs/wwaSelectLocationTemplate.html',
                            controller: 'wwaSelectLocationController'
                        }
                    }
                }
            ]

            scope.widgets = $localStorage.widgets || [
            ];

            scope.$watch('widgets', function(){
                $localStorage.widgets = scope.widgets;
            }, true);
        }
    }
}]);