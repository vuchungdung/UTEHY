(function (app) {
    app.controller('loginController', ['$scope', 'loginService', '$injector','$loading',
        function ($scope, loginService, $injector,$loading) {          
            $scope.loginData = {
                userName: "",
                password: ""
            };

            $scope.loginSubmit = function () {
                $loading.start('sample');
                loginService.login($scope.loginData.userName, $scope.loginData.password).then(function (response) {
                    if (response != null && response.data.error != undefined) {
                        $loading.finish('sample');

                        new PNotify({
                            text: 'Vui lòng kiểm tra lại tài khoản hoặc mật khẩu!',
                            addclass: 'bg-danger'
                        });
                    }
                    else {
                        $loading.finish('sample');
                        var stateService = $injector.get('$state');
                        stateService.go('home');
                    }
                });
            }
        }]);
})(angular.module('utehy'));