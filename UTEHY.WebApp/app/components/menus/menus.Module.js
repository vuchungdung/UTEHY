(function () {
    angular.module('utehy.menus',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('menus', {
                url: '/menus',
                parent: 'base',
                templateUrl: "/app/components/menus/menusListView.html",
                controller: "menusController"
            })
    };
})();