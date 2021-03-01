(function (app) {
    app.controller('facultiesController', facultiesController);

    facultiesController.$inject = ['$scope', 'apiService', '$filter', 'commonService', '$ngBootbox'];

    function facultiesController($scope, apiService, $filter, commonService, $ngBootbox) {
        $(window).load(function () {
            $('#pageSize').val('10');
        });      

        $scope.getFacultyById = function (id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/facultyapi/getsingle', config, function (result) {
                if (result) {
                    $scope.facultybyid = result.data;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.curPage = 1;
        $scope.getPagingFaculties = function (page) {
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
            apiService.post('/api/facultyapi/getallpaging', config.params, function (result) {
                if (result.status == 200) {
                    console.log(result.data.ListItem);
                    $scope.listFaculties = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        };

        $scope.searchFaculties = function () {
            $scope.getPagingFaculties($scope.page);
        }

        $scope.faculty = {};

        $scope.addFaculty = function () {
            apiService.post('/api/facultyapi/add', $scope.faculty, function (result) {
                if (result.data == true) {
                    new PNotify({
                        text: 'Thêm danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.faculty = angular.copy({});
                    $scope.getPagingFaculties($scope.curPage);
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
                angular.forEach($scope.listFaculties, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listFaculties, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        };

        $scope.$watch("listFaculties", function (n, o) {
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

        $scope.editFaculty = function () {
            apiService.put('/api/facultyapi/update', $scope.facultybyid, function (result) {
                if (result.status == 200) {
                    new PNotify({
                        text: 'Cập nhật danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.facultybyid = angular.copy({});
                    $scope.getFaculties();
                    $scope.getPagingFaculties($scope.curPage);
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

        $scope.deleteFaculty = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    facultyId: id
                }
                apiService.del('/api/facultyapi/delete', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getFaculties();
                        $scope.getPagingFaculties($scope.curPage);
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
                apiService.del('/api/facultyapi/deletemulti', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                    $scope.getFaculties();
                    $scope.getPagingFaculties($scope.curPage);
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

        $scope.getPagingFaculties($scope.page);
    }
})(angular.module('utehy.faculties'));