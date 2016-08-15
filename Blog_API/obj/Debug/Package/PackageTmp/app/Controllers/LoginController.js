(function () {
    'use strict'

    angular.module('myApp')
           .controller('LoginController', LoginController);

    function LoginController($scope, $http, HttpFactory, authService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authService.login($scope.loginData)
                       .then(function (response) {
                           $location.path('/Home');
                       },
                       function (error) {
                           $scope.message = error.error_description;
                       });
        }
    }

    LoginController.$inject = ['$scope', '$http', 'HttpFactory','authService'];
})();