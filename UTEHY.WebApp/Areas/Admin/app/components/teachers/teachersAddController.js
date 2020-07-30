(function (app) {
    app.controller('teachersAddController', teachersAddController);

    teachersAddController.$inject = ['$scope', 'notificationService', 'ajaxService'];

    function teachersAddController($scope,notificationService,ajaxService) {
        $scope.ckeditorOptions = {
            languague: 'vi',
            height: '200px'
        }
        $scope.chooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileUrl) {
                $('#input_img').val(fileUrl);
                $scope.teacher.Img = fileUrl;
            }
            finder.popup();
        }
        $scope.addTeacher = addTeacher;
        function addTeacher() {
        }
    }
})(angular.module('utehy.teachers'));