
(function () {
    angular.module('utehy.roles',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('roles', {
                url: '/roles',
                parent: 'base',
                templateUrl: "/app/components/roles/rolesListView.html",
                controller: "permissionsController"
            })
    };
})();