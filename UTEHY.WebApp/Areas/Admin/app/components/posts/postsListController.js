(function (app) {
    app.controller('postsListController', postsListController);

    postsListController.$inject = ['$scope', 'ajaxService','$filter', 'commonService', '$ngBootbox']

    function postsListController($scope,ajaxService,$filter,$ngBootbox) {
        $scope.page = 1;
        $scope.keyword = '';
        $scope.groupid = '';
        $scope.pageSize = 10;
        $scope.currentPage = 0;
        $scope.getPagingPosts = function (page) {
            $scope.currentPage = page;
            var config = {
                params: {
                    pageIndex: page,
                    pageSize: $scope.pageSize,
                    keyword: $scope.keyword,
                    groupId: $scope.groupid
                }
            }
            ajaxService.get('/Admin/Post/GetAllPaging', config, function (result) {
                if (result.data.result != null) {
                    $scope.listPosts = result.data.result.ListItem;
                    $scope.totalRecords = result.data.result.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        };
        $scope.getPagingPosts($scope.page);
        $scope.deletePost = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa dữ liệu này không?').then(function () {
                var config = {
                    postId: id
                }
                ajaxService.post('/Admin/Post/DeletePost', config, function (result) {
                    if (result.data.result != null) {
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
                ajaxService.post('/Admin/Post/DeleteMulti', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                    $scope.getPagingPosts($scope.curentPage);
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
    }

})(angular.module('utehy.posts'));