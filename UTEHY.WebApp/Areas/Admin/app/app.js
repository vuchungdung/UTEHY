(function () {
    angular.module('utehy',
        ['utehy.common','utehy.categories','utehy.teachers','utehy.posts'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/Areas/Admin/app/shared/views/baseview.html',
                abstract: true
            })
            .state('home', {
                url: '/admin',
                parent: 'base',
                templateUrl: '/Areas/Admin/app/components/homes/homeview.html',
                controller: "homeController"
            })
            .state('login', {
                url: '/login',
                templateUrl: '/Areas/Admin/app/components/logins/loginview.html',
                controller: "loginController"
            })
    };
})();