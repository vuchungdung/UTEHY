(function (app) {
    app.controller('categoriesListController', categoriesListController);

    categoriesListController.$inject = ['$scope', 'ajaxService', 'notificationService'];

    function categoriesListController($scope, ajaxService, notificationService) {

        $scope.page = 0; //pageindex

        $scope.pageCount = 0; //pageSize

        $scope.keyword = '' //keyword


        function getPagingCategories(page) {

            page = page || 0;

            var config = {
                params: {
                    keyword: $scope.keyword,                    
                    pageSize: 10,
                    pageIndex: 1

                }
            }

            ajaxService.get('/Admin/PostCategory/GetAllPaging', config, function (result) {
                if (result.data != null) {
                    console.log(result.data);
                    $scope.listCategories = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        getPagingCategories();
    }
})(angular.module('utehy.categories'));