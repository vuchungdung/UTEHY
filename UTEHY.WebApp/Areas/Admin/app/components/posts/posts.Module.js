(function () {
    angular.module('utehy.posts',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('posts', {
                url: '/posts_list',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/posts/postsListView.html",
                controller: "postsListController"
            })
            .state('posts_add', {
                url: '/posts_add',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/posts/postsAddView.html",
                controller: "postsAddController"
            })
            .state('posts_edit', {
                url: '/posts_edit',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/posts/postsEditView.html",
                controller: "postsEditController"
            })
    };
})();