(function () {
    angular.module('utehy.templates',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('templates', {
                url: '/templates',
                parent: 'base',
                templateUrl: "/app/components/templates/templatesListView.html",
                controller: "templatesController"
            })
    };
})();