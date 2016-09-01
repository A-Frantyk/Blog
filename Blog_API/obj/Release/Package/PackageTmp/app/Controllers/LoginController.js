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

            console.log("LoginController tests")

            authService.login($scope.loginData)
                       .then(function (response) {
                           $location.path('/Home');
                       },
                       function (error) {
                           $scope.message = error.error_description;
                       });
        }


        // testing modal approach of login window
        
        $scope.item = item;

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        // end testing
    }

    LoginController.$inject = ['$scope', '$http', 'HttpFactory', 'authService'];
})();