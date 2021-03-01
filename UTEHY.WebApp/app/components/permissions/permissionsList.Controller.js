(function (app) {
    app.controller('permissionsController', permissionsController);

    permissionsController.$inject = ['$scope', 'apiService', '$ngBootbox'];

    function permissionsController($scope, apiService, $ngBootbox) {

        $scope.checked = true;
        $scope.listPermissons = "";
        $scope.roleId = "";

        function getPermission(roleid) {

            var config = {
                params: {
                    roleId: roleid
                }
            
            }

            

            apiService.get("/api/roleapi/getpermission", config, function (response) {
                $scope.listPermissons = response.data;
                console.log($scope.listPermissons);
            }, function (error) {
                console.log(error);
            });
        }

        $scope.loadDataPermissions = function (roleid) {
            var config = {
                params: {
                    roleId : roleid
                }
            }
            
            $scope.roleId = roleid;
            

            
            $scope.listPermissons = getPermission($scope.roleId);

            apiService.get("/api/permissionapi/getcommandview", config, function (response) {
                if (response.status == 200) {
                    const map = {};
                    $scope.commandview = [];
                    for (let i = 0; i < response.data.length; i++) {
                        const node = response.data[i];
                        node.children = [];
                        map[node.FunctionId] = i;
                        if (node.ParentId !== null) {
                            delete node.children;
                            response.data[map[node.ParentId]].children.push(node);
                        } else {
                            $scope.commandview.push(node);
                        }
                    }
                    console.log($scope.commandview);
                    getPermission(roleid);
                }
            }, function (err) {

            });
        };

        $scope.checkedCommand = function (functionId, commandId) {
            for (var i = 0; i < $scope.listPermissons.length; i++) {
                if ($scope.listPermissons[i].CommandId == commandId && $scope.listPermissons[i].FunctionId == functionId) {
                    return true;
                }
                else {
                    continue;
                }             
            }
        }
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