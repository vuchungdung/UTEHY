(function (app) {
    app.filter('dateFilter', function () {
        return function (result,input) {
            input = input.substr(6, 13);
            result = input;
            return result;
        }
    })
})(angular.module('utehy.common'));