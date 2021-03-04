(function (app) {
    app.service('permissionService', permissionService);

    apiService.$inject = ['$http', 'authenticationService'];

    function permissionService($http, authenticationService) {
        return {
            list: list
        }
        function list() {
            authenticationService.setHeader();
            $http.get("/api/permissionapi/getprofile").then(function (result) {
                success(result){
                    return result.data;
                }
            }, function (error) {
                failure(error);
            });
        }
    }
})(angular.module('utehy.common'));