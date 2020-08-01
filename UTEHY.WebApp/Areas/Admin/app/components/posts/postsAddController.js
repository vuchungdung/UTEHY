(function (app) {
    app.controller('postsAddController', postsAddController);

    postsAddController.$inject = ['$scope','ajaxService'];

    function postsAddController($scope) {
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $('#input_img').val(fileUrl);
                $scope.posts.Img = fileUrl;
            }
            finder.popup();
        }
        $scope.addPost = addPost;
        function addPost() {

        }
    }

})(angular.module('utehy.posts'));