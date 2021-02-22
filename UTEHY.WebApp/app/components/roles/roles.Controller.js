(function (app) {
    app.controller('rolesController', rolesController);

    rolesController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function rolesController($scope, apiService, $ngBootbox) {

        $scope.page = 1;
        $scope.keyword = '';
        $scope.categoryid = '';
        $scope.pageSize = 10;
        $scope.currentPage = 0;
        $scope.getPaging = function (page) {
            $scope.currentPage = page;
            var config = {
                params: {
                    pageIndex: page,
                    pageSize: $scope.pageSize,
                    keyword: $scope.keyword,
                    categoryId: $scope.categoryid
                }
            }
            apiService.post('/api/roleapi/getpaging', config.params, function (result) {
                if (result.status == 200) {
                    $scope.listRoles = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.deleteRole = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa dữ liệu này không?').then(function () {
                var config = {
                    postId: id
                }
                apiService.post('/api/roleapi/delete', config, function (result) {
                    if (result.status == 200) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getPaging($scope.currentPage);
                    }
                    else {
                        new PNotify({
                            title: 'Hệ thống có lỗi không thể xóa được',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-danger stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                }, function (error) {
                    new PNotify({
                        title: 'Hệ thống có lỗi không thể xóa được',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-danger stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                });
            }, function (error) {
                console.log(error);
            });
        };

        $scope.isAll = false;
        $scope.selectAll = function () {
            if ($scope.isAll === false) {
                angular.forEach($scope.listRoles, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listRoles, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        };

        $scope.$watch("listRoles", function (n, o) {
            var checked = [];
            if (typeof n != "undefined") {
                checked = $filter("filter")(n, { checked: true });
            }
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteMultiple = function () {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa các dữ liệu này?').then(function () {
                var config = {
                    listId: listId
                }
                apiService.del('/api/postapi/deletemulti', config, function (result) {
                    if (result.status == null) {
                        new PNotify({
                            title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                    $scope.getPaging($scope.currentPage);
                }, function (error) {
                    new PNotify({
                        title: 'Hệ thống có lỗi không thể xóa được',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-danger stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                });
            }, function (error) {
                console.log(error);
            });
        }

        $scope.searchRoles = function () {
            $scope.getPaging($scope.page);
        }
        $scope.getPaging($scope.page);
    }
})(angular.module('utehy.roles'));