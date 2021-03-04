(function (app) {
    'use strict';

    app.directive('appPermission', appPermission);

    appPermission.$inject = ['permissionService'];

    function appPermission(permissionService) {
        for (var i = 0; i < permissionService.list().lenght; i++) {

        }
        return {
            scope: true,
            restrict: 'A',
            link: function (scope, element, attributes) {
                element.addClass('customClass');
            }

        }
    }
})(angular.module('utehy.common'));