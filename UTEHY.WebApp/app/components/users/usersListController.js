(function (app) {
    app.controller('usersListController', usersListController);

    usersListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function usersListController($scope, apiService, $ngBootbox) {


    }
})(angular.module('utehy.users'));