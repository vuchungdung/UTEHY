(function () {
    angular.module('utehy.faculties',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('faculties', {
                url: '/faculties',
                parent: 'base',
                templateUrl: "/app/components/faculties/facultiesListView.html",
                controller: "facultiesController"
            })
    };
})();