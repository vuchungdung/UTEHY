(function () {
    angular.module('utehy.categories',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('post_categories', {
                url: '/post_categories',
                parent: 'base',
                templateUrl: "/app/components/post_categories/post_categoriesListView.html",
                controller: "categoriesController"
            })
    };
})();