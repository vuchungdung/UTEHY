(function () {
    angular.module('utehy.teachers',
        ['utehy.common'])
        .config(config);

    config.$inject = ['$stateProvider'];

    function config($stateProvider) {
        $stateProvider
            .state('teachers', {
                url: '/teachers_list',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersList.html",
                controller: "teachersListController"
            })
            .state('teachers_add', {
                url: '/teachers_add',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersAdd.html",
                controller: "teachersAddController"
            })
            .state('teachers_edit', {
                url: '/teachers_edit',
                templateUrl: "/Areas/Admin/app/components/teachers/teachersEdit.html",
                controller: "teachersEditController"
            })
    };
})();