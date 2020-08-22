(function (app) {
    app.controller('permissionsController', permissionsController);

    permissionsController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function permissionsController($scope, apiService, $ngBootbox) {
        
        $scope.loadDataPermissions = function (roleid) {
            var config = {
                params: {
                    roleId : roleid
                }
            }
            apiService.get("/api/permissionapi/getcommandview", config, function (response) {
                if (response.status == 200) {
                    const map = {};
                    $scope.listPermission = [];
                    for (let i = 0; i < response.data.length; i++) {
                        const node = response.data[i];
                        node.children = [];
                        map[node.FunctionId] = i;
                        if (node.ParentId !== null) {
                            delete node.children;
                            response.data[map[node.ParentId]].children.push(node);
                        } else {
                            $scope.listPermission.push(node);
                        }
                    }
                    console.log($scope.listPermission);
                }
            }, function (err) {

            });
        };
        $scope.loadRole = function () {
            apiService.get("/api/roleapi/getall", null, function (response) {
                if (response.status == 200) {
                    $scope.listRole = response.data;                   
                }
            }, function (err) {
                console.log("Not Found");
            });
        }
        $scope.loadRole();
    }
})(angular.module('utehy.permissions'));