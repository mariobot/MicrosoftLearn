'use strict'

angular.module("psMenu").directive("psMenuItem", function(){
    return {
        require: "^psMenu",
        templateUrl: "ext-modules/psMenu/psMenuItemTemplate.html",
        link: function(scope, el, attr, ctrl){

        }
    }
})