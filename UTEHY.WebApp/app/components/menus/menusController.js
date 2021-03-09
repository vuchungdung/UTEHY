(function (app) {
    app.controller('menusController', menusController);

    menusController.$inject = ['$scope', 'apiService','$filter', 'commonService','$ngBootbox'];

    function menusController($scope, apiService, $filter, commonService, $ngBootbox) {
        $(window).load(function () {
            $('#pageSize').val('10');
        });        

        $scope.getMenuById = function (id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/menuapi/getsingle', config, function (result) {
                if (result) {
                    $scope.menubyid = result.data;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.curPage = 0;
        $scope.getPagingMenus = function (page) {
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
            apiService.post('/api/menuapi/getpaging', config.params, function (result) {
                if (result.status == 200) {                
                    $scope.listMenus = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        };
        $scope.getListMenuId = function () {
            apiService.get('/api/menuapi/getall', null, function (result) {
                if (result.status == 200) {
                    $scope.listMenuId = result.data;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getListMenuId();
        $scope.searchMenus = function () {
            $scope.getPagingMenus($scope.page);
        }
        
        $scope.menu = {};
        $scope.getSeoAlias = function () {
            $scope.menu.Alias = commonService.getSeoTitle($scope.menu.Name);
        };

        $scope.getSeoAliasEdit = function () {
            $scope.menubyid.Alias = commonService.getSeoTitle($scope.menubyid.Name);
        };

        $scope.addMenu = function () {
            apiService.post('/api/menuapi/add', $scope.menu, function (result) {
                if (result.data == true) {
                    new PNotify({
                        text: 'Thêm danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.menu = angular.copy({});
                    $scope.getPagingMenus($scope.curPage);
                }
                else {
                    new PNotify({
                        text: 'Thêm danh mục thất bại!',
                        addclass: 'bg-danger'
                    });
                }
            }, function (error) {
                new PNotify({
                    text: 'Thêm danh mục thất bại!',
                    addclass: 'bg-danger'
                });
            })
        };

        $scope.isAll = false;
        $scope.selectAll = function () {
            if ($scope.isAll === false) {
                angular.forEach($scope.listMenus, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listMenus, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        };

        $scope.$watch("listMenus", function (n, o) {
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

        $scope.editMenu = function () {
            apiService.put('/api/menuapi/update', $scope.menubyid, function (result) {
                if (result.status == 200) {
                    new PNotify({
                        text: 'Cập nhật danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.menubyid = angular.copy({});
                    $scope.getMenus();
                    $scope.getPagingMenus($scope.curPage);
                }
                else {
                    new PNotify({
                        text: 'Cập nhật danh mục thất bại!',
                        addclass: 'bg-danger'
                    });
                }
            }, function (error) {
                new PNotify({
                    text: 'Cập nhật danh mục thất bại!',
                    addclass: 'bg-danger'
                });
            });
        };

        $scope.deleteMenu = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    menuId: id
                }
                apiService.del('/api/menuapi/delete', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getMenus();
                        $scope.getPagingMenus($scope.curPage);
                    }
                }, function (error) {
                    new PNotify({
                        title: 'Hệ thống có lỗi không thể xóa được',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-danger stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                });
            });
        };

        $scope.deleteMultiple = function () {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });

            $ngBootbox.confirm('Bạn có muốn xóa các dữ liệu này?').then(function () {
                var config = {
                    listId: listId
                }
                apiService.del('/api/menuapi/deletemulti', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                    $scope.getMenus();
                    $scope.getPagingMenus($scope.curPage);
                }, function (error) {
                    new PNotify({
                        title: 'Hệ thống có lỗi không thể xóa được',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-danger stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                });
            });
        };

        $scope.getPagingMenus($scope.page);
    }
})(angular.module('utehy.menus'));