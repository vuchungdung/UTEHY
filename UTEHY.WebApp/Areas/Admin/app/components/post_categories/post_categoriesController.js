(function (app) {
    app.controller('categoriesController', categoriesController);

    categoriesController.$inject = ['$scope', 'ajaxService','$filter', 'commonService','$ngBootbox'];

    function categoriesController($scope, ajaxService, $filter, commonService, $ngBootbox) {
        $scope.getCategories = function () {
            ajaxService.get('/Admin/PostCategory/GetAll', null, function (result) {
                if (result) {
                    $scope.dropdownCategory = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getCategories();

        $scope.getCategoryById = function (id) {
            var config = {
                params: {
                    id: id
                }
            }
            ajaxService.get('/Admin/PostCategory/GetCategoryById', config, function (result) {
                if (result) {
                    $scope.categorybyid = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.keyword = '';
        $scope.page = 1;
        $scope.pageSize = 10;
        $(window).load(function () {
            $('#pageSize').val('10');
        })
        $scope.getPagingCategories = function (page) {
            $('#check').removeAttr('checked');
            $scope.isAll = false;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageSize: $scope.pageSize,
                    pageIndex: page
                }
            }
            ajaxService.get('/Admin/PostCategory/GetAllPaging', config, function (result) {
                if (result) {
                    $scope.listCategories = result.data.result.ListItem;
                    $scope.totalRecords = result.data.result.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.searchCategories = function () {
            $scope.getPagingCategories($scope.page);
        }
        
        $scope.category = {};
        $scope.getSeoAlias = function () {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
        }

        $scope.getSeoAliasEdit = function () {
            $scope.categorybyid.Alias = commonService.getSeoTitle($scope.categorybyid.Name);
        }

        $scope.addCategory = function () {
            ajaxService.post('/Admin/PostCategory/AddCategory', $scope.category, function (result) {
                if (result.data.result == true) {
                    new PNotify({
                        text: 'Thêm danh mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.resetForm();
                    $scope.getCategories();
                    $scope.getPagingCategories($scope.page);
                }
            }, function (error) {
                    new PNotify({
                        text: 'Thêm danh mục thất bại!',
                        addclass: 'bg-danger'
                    });
            })
        }
        $scope.isAll = false;
        $scope.selectAll = function () {
            if ($scope.isAll === false) {
                angular.forEach($scope.listCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.listCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("listCategories", function (n, o) {
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

        $scope.editCategory = function () {
            ajaxService.post('/Admin/PostCategory/UpdateCategory', $scope.categorybyid, function (result) {
                if (result.data.result != null) {
                    new PNotify({
                        text: 'Cập nhật mục thành công!',
                        addclass: 'bg-success'
                    });
                    $scope.resetForm();
                    $scope.getCategories();
                    $scope.getPagingCategories($scope.page);
                }
            }, function (error) {
                new PNotify({
                    text: 'Cập nhật mục thành công!',
                    addclass: 'bg-danger'
                });
            });
        }

        $scope.deleteCategory = function () {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    categoryId: id
                }
                ajaxService.post('/Admin/PostCategory/DeleteCategory', config, function (result) {
                    if (result.data.result != null) {
                        new PNotify({
                            title: 'Đã xóa thành công',
                            icon: 'icon-checkmark3',
                            addclass: 'bg-success stack-bottom-right',
                            stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                        });
                        $scope.getCategories();
                        $scope.getPagingCategories($scope.page);
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
        }

        $scope.deleteMultiple = function () {
            var listId = [];
            $.each($scope.selected, function (i, item) {
                listId.push(item.ID);
            });
            var config = {
                listId: listId
            }
            ajaxService.post('/Admin/PostCategory/DeleteMulti', config, function (result) {
                if (result.data.result != null) {
                    new PNotify({
                        title: 'Đã xóa thành công ' + result.data.result + ' bản ghi',
                        icon: 'icon-checkmark3',
                        addclass: 'bg-success stack-bottom-right',
                        stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                    });
                }
                $scope.getCategories();
                $scope.getPagingCategories();
            }, function (error) {
                new PNotify({
                    title: 'Hệ thống có lỗi không thể xóa được',
                    icon: 'icon-checkmark3',
                    addclass: 'bg-danger stack-bottom-right',
                    stack: { "dir1": "up", "dir2": "left", "firstpos1": 25, "firstpos2": 25 }
                });
            });
        }

        $scope.resetForm = function () {
            $scope.category = angular.copy({});
        }

        $scope.getPagingCategories($scope.page);
    }
})(angular.module('utehy.categories'));