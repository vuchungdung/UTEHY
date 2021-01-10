(function (app) {
    app.controller('templatesController', templatesController);

    templatesController.$inject = ['$scope', 'apiService', '$filter', 'commonService', '$ngBootbox'];

    function templatesController($scope, apiService, $filter, commonService, $ngBootbox) {

        $(window).load(function () {
            $('#pageSize').val('10');
        });

        $scope.getTemplateById = function (id) {
            var config = {
                params: {
                    id: id
                }
            }
            apiService.get('/api/templateapi/getsingle', config, function (result) {
                if (result) {
                    $scope.templatebyid = result.data;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.curPage = 1;
        $scope.getPagingTemplates = function (page) {
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
            apiService.post('/api/templateapi/getpaging', config.params, function (result) {
                if (result.status == 200) {
                    $scope.listTemplates = result.data.ListItem;
                    $scope.totalRecords = result.data.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        };

        $scope.searchTemplates = function () {
            $scope.getPagingTemplates($scope.page);
        }

        $scope.template = {};
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.template.Image = fileUrl;
                })               
            }
            finder.popup();
        }
        $scope.addTemplate = function () {
            apiService.post('/api/templateapi/add', $scope.template, function (result) {
                if (result.data == true) {
                    new PNotify({
                        text: 'Thêm danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.template = angular.copy({});
                    $scope.getPagingTemplates($scope.curPage);
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
                angular.forEach($scope.listTemplates, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listTemplates, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        };

        $scope.$watch("listTemplates", function (n, o) {
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

        $scope.editTemplate = function () {
            apiService.put('/api/templateapi/update', $scope.templatebyid, function (result) {
                if (result.status == 200) {
                    new PNotify({
                        text: 'Cập nhật danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.templatebyid = angular.copy({});
                    $scope.getTemplates();
                    $scope.getPagingTemplates($scope.curPage);
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

        $scope.deleteTemplate = function (id) {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    templateId: id
                }
                apiService.del('/api/templateapi/delete', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getTemplates();
                        $scope.getPagingTemplates($scope.curPage);
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
                apiService.del('/api/templateapi/deletemulti', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                    }
                    $scope.getTemplates();
                    $scope.getPagingTemplates($scope.curPage);
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

        $scope.getPagingTemplates($scope.page);
    }
})(angular.module('utehy.templates'));