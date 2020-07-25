(function (app) {
    app.controller('categoriesListController', categoriesListController);

    categoriesListController.$inject = ['$scope', 'ajaxService', 'notificationService'];

    function categoriesListController($scope,ajaxService,notificationService) {

    }
})(angular.module('utehy.categories'));