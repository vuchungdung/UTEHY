(function (app) {
    app.controller('categoriesController', categoriesController);

    categoriesController.$inject = ['$scope', 'ajaxService', 'notificationService', '$filter', 'commonService'];

    function categoriesController($scope, ajaxService, notificationService, $filter, commonService) {
        //Start getCategories//
        $scope.getCategories = getCategories;
        function getCategories() {
            ajaxService.get('/Admin/PostCategory/GetAll', null, function (result) {
                if (result.data != null) {
                    console.log(result.data);
                    $scope.dropdownCategory = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getCategories();
        //End getCategories//

        //Statrt getNameById//
        $scope.getCategoryById = getCategoryById;

        function getCategoryById(id) {
            var config = {
                params: {
                    id: id
                }
            }
            ajaxService.get('/Admin/PostCategory/GetCategoryById', config, function (result) {
                if (result.data != null) {
                    console.log(result.data);
                    $scope.categorybyid = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        //End getNameById//

        //Start getPagingCategories//
        $scope.page = 0; //pageindex
        $scope.pageCount = 0; //pageSize
        $scope.keyword = '' //keyword
        $scope.getPagingCategories = getPagingCategories;
        function getPagingCategories(page) {
            page = page || 1;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    pageSize: 5,
                    pageIndex: page
                }
            }
            ajaxService.get('/Admin/PostCategory/GetAllPaging', config, function (result) {
                if (result.data != null) {
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
        
        //End getPagingCategories//

        //Start getSeoAlias//
        $scope.category = {};
        $scope.getSeoAlias = getSeoAlias;
        function getSeoAlias() {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
            $scope.categorybyid.Alias = commonService.getSeoTitle($scope.categorybyid.Name);
        }
        //End getSeoAlias//

        //Start AddCategory//
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
        //End getCategory//

        //Start DeleteMulti//
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
        //End DeleteMulti//
    }
})(angular.module('utehy.categories'));