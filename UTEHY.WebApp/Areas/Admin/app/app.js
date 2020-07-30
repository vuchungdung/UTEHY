(function () {
    angular.module('utehy',
        ['utehy.common','utehy.categories','utehy.teachers'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('home', {
                url: '/admin',
                templateUrl: '/Areas/Admin/app/components/homes/homeview.html',
                controller: "homeController"
            });
    };
})();