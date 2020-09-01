
(function () {
    angular.module('utehy.users',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('users', {
                url: '/users',
                parent: 'base',
                templateUrl: "/app/components/users/usersListView.html",
                controller: "permissionsController"
            })
    };
})();