"use strict";

angular.module('app').directive('wwaEmployee',
    ['dataService',
    function (dataService) {
        return {
            templateUrl: 'app/widgets/wwaEmployee/wwaEmployeeTemplate.html',
            link: function (scope, el, attrs) {

            }
        };
    }]);