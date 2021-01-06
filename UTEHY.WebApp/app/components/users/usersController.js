(function (app) {
    app.controller('usersListController', usersListController);

    usersListController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function usersListController($scope, apiService, $ngBootbox) {

        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.curPage = 0;

        $scope.getPagingUsers = function (page) {
            $('#check').removeAttr('checked');
            $scope.curPage = page;
            $scope.isAll = false;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageSize: $scope.pageSize,
                    pageIndex: page
                }
            }
            apiService.post('/api/userapi/getpaging', config.params, function (result) {
                if (result.status == 200) {
                    $scope.listUsers = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        }


    }
})(angular.module('utehy.users'));