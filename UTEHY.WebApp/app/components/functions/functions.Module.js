(function () {
    angular.module('utehy.functions',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('functions', {
                url: '/functions',
                parent: 'base',
                templateUrl: "/app/components/functions/functionsListView.html",
                controller: "functionsController"
            })
    };
})();