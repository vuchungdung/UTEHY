(function () {
    angular.module('utehy.posts',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('posts', {
                url: '/posts_list',
                templateUrl: "/Areas/Admin/app/components/posts/postsListView.html",
                controller: "postsListController"
            })
            .state('posts_add', {
                url: '/posts_add',
                templateUrl: "/Areas/Admin/app/components/posts/postsAddView.html",
                controller: "postsAddController"
            })
            .state('posts_edit', {
                url: '/posts_edit',
                templateUrl: "/Areas/Admin/app/components/posts/postsEditView.html",
                controller: "postsEditController"
            })
    };
})();