(function (app) {
    app.service('ajaxService', ajaxService);

    ajaxService.$inject = ['$http'];

    function ajaxService($http) {
        return {
            get: get,
            post: post,
            put: put,
            del: del
        };
        function del(url, data, success, failure) {
            $http.delete(url, data).then(function (result) {
                success(result);
            }, function (error) {
                console.log(error.status)
                if (failure != null) {
                    failure(error);
                }
            });
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
        function put(url, data, success, failure) {
            $http.put(url, data).then(function (result) {
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
})(angular.module('UTEHY.Common'))