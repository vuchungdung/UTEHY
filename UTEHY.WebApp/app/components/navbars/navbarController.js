(function (app) {
    app.controller('navbarController', navbarController);
    navbarController.$inject = ['$scope', 'apiService'];
    function navbarController($scope, apiService) {
        apiService.get('/api/userapi/getmenu', null, function (respone) {
            const map = {};
            $scope.functions = [];
            for (let i = 0; i < respone.data.length; i++) {
                const node = respone.data[i];
                node.children = [];
                map[node.FunctionId] = i;
                if (node.ParentId !== null) {
                    delete node.children;
                    respone.data[map[node.ParentId]].children.push(node);
                } else {
                    $scope.functions.push(node);
                }
            }
            console.log($scope.functions);
        }, function (error) {

        })        
    }
})(angular.module('utehy'));