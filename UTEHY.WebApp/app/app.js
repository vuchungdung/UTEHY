(function () {
    angular.module('utehy',
        ['utehy.common',
            'utehy.users',
            'utehy.roles',
            'utehy.functions',
            'utehy.permissions',
            'utehy.categories',
            'utehy.teachers',
            'utehy.posts',
            'utehy.templates',
            'utehy.faculties'])
        .config(config)
        .config(configAuthentication);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '/app/shared/views/baseview.html',
                abstract: true
            })
            .state('home', {
                url: '/admin',
                parent: 'base',
                templateUrl: '/app/components/homes/homeview.html',
                controller: "homeController"
            })
            .state('login', {
                url: '/login',
                templateUrl: '/app/components/logins/loginview.html',
                controller: "loginController"
            })
        $urlRouterProvider.otherwise('/login');
    };
    function configAuthentication($httpProvider) {
        $httpProvider.interceptors.push(function ($q, $location) {
            return {
                request: function (config) {
                    return config;
                },
                requestError: function (rejection) {
                    return $q.reject(rejection);
                },
                response: function (response) {
                    if (response.status == "401") {
                        $location.path('/login');
                    }
                    return response;
                },
                responseError: function (rejection) {
                    if (rejection.status == "401") {
                        $location.path('/login');
                    }
                    return $q.reject(rejection);
                }
            };
        });
    }
})();