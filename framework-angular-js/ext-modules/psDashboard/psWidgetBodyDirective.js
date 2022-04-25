"use strict";

angular.module('psDashboard').directive('psWidgetBody',
    ['$compile',
    function ($compile) {
        return {
            templateUrl: 'ext-modules/psDashboard/psWidgetBodyTemplate.html',
            link: function (scope, element, attrs) {
                var newElement = angular.element(scope.item.template);
                element.append(newElement);
                $compile(newElement)(scope);
            }
        };
    }
]);