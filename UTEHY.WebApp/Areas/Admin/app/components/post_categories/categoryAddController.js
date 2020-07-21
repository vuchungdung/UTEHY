(function (app) {
    app.controller('categoryAddController', categoryAddController);

    categoryAddController.$inject = ['$http', '$scope'];

    function categoryAddController($http, $scope) {
        //function getCategory() {
            //ajaxService.get('/Admin/PostCategory/GetAll', null, function (result) {
            //    if (result.data != null) {
            //        console.log(result.data);
            //        $scope.listCategory = result.data;
            //    }
            //}, function (error) {
            //    console.log(error);
            //});
            
        //}
        var result = $http({
            method: "GET",
            url: '/Admin/PostCategory/GetAll',
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        result.then(function (respone) {
            $scope.listCategory = respone.data.result;
            console.log($scope.listCategory);
        });
    }
})(angular.module('UTEHY.Category'));