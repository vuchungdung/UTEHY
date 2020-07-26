(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'apiService',
        function ($http, $q, apiService) {
            var userInfo;
            var deferred;

            this.login = function (userName, password) {
                deferred = $q.defer();
                var data = {
                    UserName: userName,
                    Password: password
                }
                debugger
                $http({
                    method: "post",
                    url: "/api/accounts/authen",
                    datatype: "json",
                    data: data
                }).then(function (response) {
                    alert(response.data);
                })  
            }

            this.logOut = function () {
                apiService.post('/api/accounts/logout', null, function (response) {
                    

                }, null);

            }
        }]);
})(angular.module('utehy.common'));