'use strict';

angular.module("psMenu").controller("psMenuController", 
    ["$scope","$rootScope", 
        function($scope, $rootScope){
            $scope.showMenu = true;
            $scope.isVertical = true;

            this.getActiveElement = function(){
                return $scope.activeElement;
            }

            this.setActiveElement = function(el){
                $scope.activeElement = el;
            };

            this.isVertical = function(){
                return $scope.isVertical;
            }

            this.setRoute = function(route){
                $rootScope.$broadcast("ps-menu-item-selected-event", {
                    route: route
                }); 
            };

            $scope.$on("ps-menu-show", function(evt, data){
                $scope.showMenu = data.show;
            })

            $scope.toggleMenuOrientation = function(){
                $scope.isVertical = !$scope.isVertical;
                $rootScope.$broadcast("ps-menu-orientation-ghanged-event", {
                    isMenuVertical: $scope.isVertical
                });
            }
        }
    ]);