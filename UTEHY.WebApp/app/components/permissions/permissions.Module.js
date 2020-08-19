(function () {
    angular.module('utehy.permissions',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('permissions', {
                url: '/permissions',
                parent: 'base',
                templateUrl: "/app/components/permissions/permissionsListView.html",
                controller: "permissionsController"
            })
    };
})();