(function (app) {
    app.controller('postsAddController', postsAddController);

    postsAddController.$inject = ['$scope', 'apiService', '$state','commonService'];

    function postsAddController($scope, apiService, $state, commonService) {
        $(window).load(function () {
            $('#pageSize').val('10');
        });
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '280px'
        }
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.post.Img = fileUrl;
                })               
            }
            finder.popup();
        }
        $scope.moreImages = [];
        $scope.chooseMoreImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $scope.$apply(function () {
                    $scope.moreImages.push(fileUrl);
                });
            }
            finder.popup();
        }
        $scope.addPost = function () {
            $scope.post.MoreImgs = JSON.stringify($scope.moreImages);
            apiService.post('/api/postapi/add', $scope.post, function (result) {
                if (result.data.result == true) { 
                    $scope.post = angular.copy({});   
                    new PNotify({
                        text: 'Thêm bài đăng thành công!',
                        addclass: 'bg-success'
                    });
                    $state.go('posts');                                    
                }
                else {
                    new PNotify({
                        text: 'Thêm bài đăng thất bại!',
                        addclass: 'bg-danger'
                    });
                }
            }, function (error) {
                new PNotify({
                    text: 'Thêm danh mục thất bại!',
                    addclass: 'bg-danger'
                });
            })
        }

        $scope.getSeoAlias = function () {
            $scope.post.Alias = commonService.getSeoTitle($scope.post.Name);
        }

        $scope.getListCategoryId = function () {
            apiService.get('/api/postcategoryapi/getall', null, function (result) {
                if (result) {
                    $scope.listCategoryId = result.data.result;
                }
            }, function (error) {
                console.log(error);
            });
        }
        $scope.getListCategoryId();
    }

})(angular.module('utehy.posts'));