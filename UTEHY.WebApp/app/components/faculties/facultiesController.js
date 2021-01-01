(function (app) {
    app.controller('facultiesController', facultiesController);

    facultiesController.$inject = ['$scope', 'apiService', '$filter', 'commonService', '$ngBootbox'];

    function facultiesController($scope, apiService, $filter, commonService, $ngBootbox) {

    }
})(angular.module('utehy.faculties'));