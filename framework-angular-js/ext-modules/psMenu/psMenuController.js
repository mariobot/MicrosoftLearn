'use strict';

angular.module("psMenu").controller("psMenuController", 
    ["$scope","$rootScope", 
        function($scope, $rootScope){
            this.getActiveElement = function(){
                return $scope.activeElement;
            }

            this.setActiveElement = function(el){
                $scope.activeElement = el;
            };

            this.setRoute = function(route){
                $rootScope.$broadcast("ps-menu-item-selected-event", {
                    route: route
                }); 
            };
        }
    ]);