(function (app) {
    app.controller('categoriesController', categoryAddController);

    categoriesController.$inject = ['ajaxService', '$scope','commonService','notificationService'];

    function categoriesController(ajaxService, $scope, commonService, notificationService) {
        function getCategory() {
            ajaxService.get('/Admin/PostCategory/GetAll', null, function (result) {
                if (result.data != null) {
                    console.log(result.data);
                    $scope.listCategories = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });           
        }
        getCategory();
        $scope.getSeoAlias = getSeoAlias;
        function getSeoAlias() {
            $scope.category.Alias = commonService.getSeoTitle($scope.category.Name);
            var id = (commonService.getSeoTitle($scope.category.Name)).toUpperCase();
            id = id.replace(/-/gi, "_");
            $scope.category.ID = id;
        }
        $scope.addCategory = addCategory;
        function addCategory() {
            ajaxService.post('/Admin/PostCategory/AddCategory', $scope.category, function (result) {
                if (result.data.result == true) {
                    notificationService.displaySuccess($scope.category.Name + " đã được thêm thành công.");
                    getCategory();
                }
            }, function (error) {
                notificationService.displayError('Thêm thất bại.');
            })
        }
    }
})(angular.module('UTEHY'));