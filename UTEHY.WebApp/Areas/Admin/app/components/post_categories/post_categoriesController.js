(function (app) {
    app.controller('categoriesController', categoriesController);

    categoriesController.$inject = ['$scope', 'ajaxService', 'notificationService', '$filter', 'commonService','$ngBootbox'];

    function categoriesController($scope, ajaxService, notificationService, $filter, commonService, $ngBootbox) {
        $scope.getCategories = getCategories;
        function getCategories() {
            ajaxService.get('/Admin/PostCategory/GetAll', null, function (result) {
                if (result) {
                    console.log(result.data);
                    $scope.dropdownCategory = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getCategories();

        $scope.getCategoryById = getCategoryById;

        function getCategoryById(id) {
            var config = {
                params: {
                    id: id
                }
            }
            ajaxService.get('/Admin/PostCategory/GetCategoryById', config, function (result) {
                if (result) {
                    console.log(result.data);
                    $scope.categorybyid = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }

        $scope.page = 0; 
        $scope.pageCount = 0; 
        $scope.keyword = '';
        $scope.getPagingCategories = getPagingCategories;
        function getPagingCategories(page) {
            page = page || 1;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageSize: 10,
                    pageIndex: page
                }
            }
            ajaxService.get('/Admin/PostCategory/GetAllPaging', config, function (result) {
                if (result) {
                    console.log(result.data);
                    $scope.listCategories = result.data.result.ListItem;
                    $scope.page = result.data.result.Page;
                    $scope.totalCount = result.data.result.TotalRecords;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getPagingCategories();

        $scope.searchCategories = searchCategories;
        function searchCategories() {
            getPagingCategories();
        }
        
        $scope.category = {};
        $scope.getSeoAlias = getSeoAlias;
        function getSeoAlias() {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
        }

        $scope.getSeoAliasEdit = getSeoAliasEdit;
        function getSeoAliasEdit() {
            $scope.categorybyid.Alias = commonService.getSeoTitle($scope.categorybyid.Name);
        }

        $scope.addCategory = addCategory;
        function addCategory() {
            ajaxService.post('/Admin/PostCategory/AddCategory', $scope.category, function (result) {
                if (result.data.result == true) {
                    notificationService.displaySuccess($scope.category.Name + " đã được thêm thành công.");
                    $scope.getCategories();
                    $scope.getPagingCategories();
                }
            }, function (error) {
                notificationService.displayError('Thêm thất bại.');
            })
        }

        $scope.selectAll = selectAll;
        $scope.isAll = false;
        function selectAll() {
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

        $scope.editCategory = editCategory;
        function editCategory() {
            ajaxService.post('/Admin/PostCategory/UpdateCategory', $scope.categorybyid, function (result) {
                if (result.data.result != null) {
                    notificationService.displaySuccess(result.data.result.Name + " cập nhật thành công.");
                    $scope.getCategories();
                    $scope.getPagingCategories();
                }
            }, function (error) {
                notificationService.displayError('Cập nhật thất bại.');
            });
        }

        $scope.deleteCategory = deleteCategory;
        function deleteCategory(id) {
            $ngBootbox.confirm('Bạn có muốn xóa ?').then(function () {
                var config = {
                    categoryId: id
                }
                ajaxService.post('/Admin/PostCategory/DeleteCategory', config, function (result) {
                    if (result.data.result != null) {
                        notificationService.displaySuccess("Xóa " + result.data.result.Name + " thành công.");
                        $scope.getCategories();
                        $scope.getPagingCategories();
                    }
                }, function (error) {
                    notificationService.displayError('Xóa thất bại.');
                });
            });           
        }
    }
})(angular.module('utehy.categories'));