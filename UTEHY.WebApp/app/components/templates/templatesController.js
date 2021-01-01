(function (app) {
    app.controller('templatesController', templatesController);

    templatesController.$inject = ['$scope', 'apiService', '$filter', 'commonService', '$ngBootbox'];

    function templatesController($scope, apiService, $filter, commonService, $ngBootbox) {

    }
})(angular.module('utehy.templates'));