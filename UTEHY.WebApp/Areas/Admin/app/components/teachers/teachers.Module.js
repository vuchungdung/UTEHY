(function () {
    angular.module('utehy.teachers',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('teachers', {
                url: '/teachers_list',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersListView.html",
                controller: "teachersListController"
            })
            .state('teachers_add', {
                url: '/teachers_add',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersAddView.html",
                controller: "teachersAddController"
            })
            .state('teachers_edit', {
                url: '/teachers_edit',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersEditView.html",
                controller: "teachersEditController"
            })
    };
})();