(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector',
        function ($scope, loginService, $injector) {

            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        new PNotify({
                            text: 'Vui lòng kiểm tra lại tài khoản hoặc mật khẩu!',
                            addclass: 'bg-danger'
                        });
                    }
                    else {
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);
})(angular.module('utehy'));