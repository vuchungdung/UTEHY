(function () {
    angular.module('utehy',
        ['utehy.common','utehy.categories'])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('home', {
                url: '/admin',
                templateUrl: '/Areas/Admin/app/components/homes/homeview.html',
                controller: "homeController"
            });
    };
})();