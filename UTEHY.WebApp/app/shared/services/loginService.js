(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData', 'ajaxService',
        function ($http, $q, authenticationService, authData, ajaxService) {
            var userInfo;
            var deferred;

            this.login = function (userName, password) {
                deferred = $q.defer();
                var data = {
                    UserName: userName,
                    Password: password
                }
                $http.post('/Authen/Login', data)
                    .then(function (response) {
                    userInfo = {
                        accessToken: response.data,
                        userName: userName
                    };
                    authenticationService.setTokenInfo(userInfo);
                    authData.authenticationData.IsAuthenticated = true;
                    authData.authenticationData.userName = userName;
                    authData.authenticationData.accessToken = userInfo.accessToken;

                    deferred.resolve(null);
                    }, function (err, status) {
                        authData.authenticationData.IsAuthenticated = false;
                        authData.authenticationData.userName = "";
                        deferred.resolve(err);
                    })
                    return deferred.promise;
            }

            this.logOut = function () {
                ajaxService.post('/Authen/LogOut', null, function (response) {
                    authenticationService.removeToken();
                    authData.authenticationData.IsAuthenticated = false;
                    authData.authenticationData.userName = "";
                    authData.authenticationData.accessToken = "";
                }, null);

            }
        }]);
})(angular.module('utehy.common'));