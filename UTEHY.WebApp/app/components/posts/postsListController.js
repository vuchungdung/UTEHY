﻿(function (app) {
    app.controller('postsListController', postsListController);

    postsListController.$inject = ['$scope', 'apiService', '$filter', '$ngBootbox'];

    function postsListController($scope, apiService, $filter, $ngBootbox) {

        $scope.page = 1;

        $scope.keyword = '';

        $scope.categoryid = '';

        $scope.pageSize = 10;

        $scope.currentPage = 0;

        $scope.getPagingPosts = function (page) {
            $scope.currentPage = page;
            var config = {
                params: {
                    pageIndex: page,
                    pageSize: $scope.pageSize,
                    keyword: $scope.keyword,
                    categoryId: $scope.categoryid
                }
            }
            apiService.post('/api/postapi/getpaging', config.params, function (result) {
                if (result.status == 200) {
                    $scope.listPosts = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                    console.log($scope.listPosts);
                }
            }, function (error) {
                console.log(error);
            });
        };

        $scope.deletePost = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa dữ liệu này không?').then(function () {
                apiService.del('/api/postapi/delete?postId=' + id, null, function (result) {
                    if (result.status == 200) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getPagingPosts($scope.currentPage);
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
                angular.forEach($scope.listPosts, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listPosts, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        };

        $scope.$watch("listPosts", function (n, o) {
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
                    $scope.getPagingPosts($scope.currentPage);
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

        $scope.searchPosts = function () {
            $scope.getPagingPosts($scope.page);
        }

        $scope.getPagingPosts($scope.page);

        $scope.changeStatus = function (id, status) {
            if (typeof id != "undefined") {
                var st = status == 1 ? 0 : 1;
                var config = {
                    params: {
                        id: id,
                        status: st
                    }
                }
                apiService.post('/api/postapi/changestatus', config.params, function (result) {
                    if (result.status == 200) {
                        new PNotify({
                            text: 'Cập nhật thành công!',
                            addclass: 'bg-success'
                        });
                    }
                }, function (error) {
                    new PNotify({
                        text: 'Có lỗi xảy ra!',
                        addclass: 'bg-danger'
                    });
                });
            }
            else {
                console.log('Hello! bạn nhấm F12 nhằm mục đích gì đấy???');
            }
        }

        $scope.changeHot = function (id, status) {           
            if (typeof id != "undefined") {
                var st = status == true ? false : true;
                var config = {
                    params: {
                        id: id,
                        status: st
                    }
                }
                apiService.post('/api/postapi/changehot', config.params, function (result) {
                    if (result.status == 200) {
                        new PNotify({
                            text: 'Cập nhật thành công!',
                            addclass: 'bg-success'
                        });
                    }
                }, function (error) {
                    new PNotify({
                        text: 'Có lỗi xảy ra!',
                        addclass: 'bg-danger'
                    });
                });
            }
            else {
                console.log('Hello! bạn nhấm F12 nhằm mục đích gì đấy???');
            }
        }

        $scope.changeHome = function (id, status) {
            if (typeof id != "undefined") {
                var st = status == true ? false : true;
                var config = {
                    params: {
                        id: id,
                        status: st
                    }
                }
                apiService.post('/api/postapi/changehome', config.params, function (result) {
                    if (result.status == 200) {
                        new PNotify({
                            text: 'Cập nhật thành công!',
                            addclass: 'bg-success'
                        });
                    }
                }, function (error) {
                    new PNotify({
                        text: 'Có lỗi xảy ra!',
                        addclass: 'bg-danger'
                    });
                });
            }
            else {
                console.log('Hello! bạn nhấm F12 nhằm mục đích gì đấy???');
            }
        }
    }

})(angular.module('utehy.posts'));