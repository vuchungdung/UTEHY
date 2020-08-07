(function (app) {
    app.service('ajaxService', ajaxService);

    ajaxService.$inject = ['$http'];

    function ajaxService($http) {
        return {
            get: get,
            post: post
        };
        function post(url, data, success, failure) {
            $http.post(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (failure != null) {
                    failure(error);
                }
            });
        };
        function get(url, params, success, failure) {
            $http.get(url, params).then(function (result) {
                success(result);
            }, function (error) {
                failure(error);
            });
        };
    }
})(angular.module('utehy.common'));