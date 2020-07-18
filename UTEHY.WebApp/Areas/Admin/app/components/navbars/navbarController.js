(function (app) {
    app.controller('navbarController', navbarController);
    navbarController.$inject = ['$scope','$http']
    function navbarController($scope, $http) {
        $http({
            method: "GET",
            url: "/User/GetMenuByUserPermission",
            dataType: 'json',
            headers: { "Content-Type": "application/json" }
        }).then(function (respone) {
            debugger
            const map = {};
            var functions = [];
            for (let i = 0; i < respone.data.result.length; i++) {
                const node = respone.data.result[i];
                node.children = [];
                map[node.FunctionId] = i;
                if (node.ParentId !== null) {
                    delete node.children;
                    respone.data.result[map[node.ParentId]].children.push(node);
                } else {
                    functions.push(node);
                }
            }
            
        });  
    }     
})(angular.module('UTEHY'));