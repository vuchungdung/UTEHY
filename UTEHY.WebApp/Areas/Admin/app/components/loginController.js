var app = angular.module('loginModule', ['ngRoute']);
app.controller('loginCtrl', ['$scope', '$http', function ($scope, $http) {

    $scope.submit = function () {
        $http({
            url: "/Admin/Authen/Login",
            method: "POST",
            params: { UserName: $scope.username, Password: $scope.password }
        }).then(function (response) {
            if (response.data.Success) {
                window.location.href = "/Admin/Home/Index";
            }
            else {
                alert("error");
            }
        }).catch(function (error) {
            alert("error");
        });
    }
}])