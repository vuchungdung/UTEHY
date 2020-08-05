(function () {
    angular.module('utehy.teachers',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('teachers', {
                url: '/teachers_list',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersListView.html",
                controller: "teachersListController"
            })
            .state('teachers_add', {
                url: '/teachers_add',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersAddView.html",
                controller: "teachersAddController"
            })
            .state('teachers_edit', {
                url: '/teachers_edit',
                parent: 'base',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersEditView.html",
                controller: "teachersEditController"
            })
    };
})();