  
﻿(function (app) {
    app.controller('rootController', rootController);

    rootController.$inject = ['$state', 'authData', 'loginService', '$scope'];

    function rootController($state, authData, loginService, $scope) {
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }
        $scope.handleOnClose = function () {
            if (window.event.clientX < 0 && window.event.clientY < 0) {
                loginService.logOut();
            }
        }
        $scope.authentication = authData.authenticationData;
    }
})(angular.module('utehy'));