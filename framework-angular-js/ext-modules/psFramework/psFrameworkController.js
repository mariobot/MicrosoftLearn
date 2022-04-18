"use strict";

angular.module("psFramework").controller("psFrameworkController",
    ['$scope', '$window', '$timeout','$rootScope',
        function ($scope, $window, $timeout, $rootScope) {

            $scope.isMenuVisible = true;
            $scope.isMenuButtonVisible = true;
            $scope.isMenuVertical = true;

            $scope.$on("ps-menu-orientation-ghanged-event", function(evt, data){
                $scope.isMenuVertical = data.isMenuVertical;
            })

            $scope.$on('ps-menu-item-selected-event', function (evt, data) {
                $scope.routeString = data.route;
                checkWidth();
                broadcastMenuState();
            });

            $($window).on('resize.psFramework', function () {
                $scope.$apply(function () {
                    checkWidth();
                    broadcastMenuState();
                });
            });
            $scope.$on("$destroy", function () {
                $($window).off("resize.psFramework"); // remove the handler added earlier
            });

            var checkWidth = function () {
                var width = Math.max($($window).width(), $window.innerWidth);
                $scope.isMenuVisible = (width >= 768);
                $scope.isMenuButtonVisible = !$scope.isMenuVisible;
            };

            $scope.menuButtonClicked = function(){
                $scope.isMenuVisible = !$scope.isMenuVisible;
                broadcastMenuState();
                $scope.$apply();
            }

            var broadcastMenuState = function(){
                $rootScope.$broadcast("ps-menu-show",{
                    show: $scope.isMenuVisible
                });
            }

            $timeout(function () {
                checkWidth();
            }, 0);

        }
    ]);