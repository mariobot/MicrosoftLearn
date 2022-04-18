'use strict'

angular.module("psMenu").directive("psMenuGroup", function(){
    return {
        require: '^psMenu',
        transclude: true,
        scope:{
            label: '@',
            icon: '@'
        },
        templateUrl : "ext-modules/psMenu/psMenuGroupTemplate.html",
        link: function(scope, el, attrs, ctrl){
            
        }
    }
});