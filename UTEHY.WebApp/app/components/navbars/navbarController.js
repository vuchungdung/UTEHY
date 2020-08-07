(function (app) {
    app.controller('navbarController', navbarController);
    navbarController.$inject = ['$scope', '$http','authData']
    function navbarController($scope, $http, authData) {
        var result = $http({
            method: "GET",
            url: "/User/GetMenuByUserPermission",
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        });
        result.then(function (respone) {
            const map = {};
            $scope.functions = [];
            for (let i = 0; i < respone.data.result.length; i++) {
                const node = respone.data.result[i];
                node.children = [];
                map[node.FunctionId] = i;
                if (node.ParentId !== null) {
                    delete node.children;
                    respone.data.result[map[node.ParentId]].children.push(node);
                } else {
                    $scope.functions.push(node);
                }
            }
            console.log($scope.functions);
        });
    }
})(angular.module('utehy'));