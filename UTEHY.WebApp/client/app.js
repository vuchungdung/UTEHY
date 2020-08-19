(function () {
    angular.module('utehy',
        [])
        .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('base', {
                url: '',
                templateUrl: '',
                abstract: true
            })            
        $urlRouterProvider.otherwise('');
    }
})();