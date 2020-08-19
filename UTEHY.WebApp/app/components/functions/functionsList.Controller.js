(function (app) {
    app.controller('functionsController', functionsController);

    functionsController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function functionsController($scope, apiService, $ngBootbox) {
        $scope.loadDataFunctions = function () {
            apiService.get("/api/", null, function (response) {


            }, function (err) {


            });
        }
    }
})(angular.module('utehy.functions'));