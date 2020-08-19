(function (app) {
    app.controller('permissionsController', permissionsController);

    permissionsController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function permissionsController($scope, apiService, $ngBootbox) {
        $scope.loadDataPermissions = function () {
            apiService.get("/api/", null, function (response) {


            }, function (err) {


            });
        }
    }
})(angular.module('utehy.permissions'));