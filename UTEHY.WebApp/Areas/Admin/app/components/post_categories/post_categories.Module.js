(function () {
    angular.module('utehy.categories',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('post_categories', {
                url:'/post_categories_list',
                templateUrl: "/Areas/Admin/app/components/post_categories/post_categories.List.html",
                controller: "categoriesListController"
            })
            .state('post_categories_add', {
                url: '/post_categories_add',
                templateUrl: "/Areas/Admin/app/components/post_categories/post_categories.Add.html",
                controller: "categoriesAddController"
            })
            .state('post_categories_edit', {
                url: '/post_categories_edit',
                templateUrl: "/Areas/Admin/app/components/post_categories/post_categories.Edit.html",
                controller: "categoriesEditController"
            })
    };
})();