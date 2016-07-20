(function () {
    'use strict'

    angular.module('myApp')
           .controller('UserController', UserController);
    function UserController($scope, $http, $q, $stateParams, HttpFactory, API_URL, UserServices) {
        $scope.User;

        $scope.getUserId = function () {
            return User.user_Number;
        }

        this.Users = [];

        var User = {
            name: null,
            last_Name: null,
            short_Information: null,
            user_Number: 0,
            education: null,
            mobile_Phone: 0,
            facebook_Link: null,
            vk_Link: null,
            mail_Link: null,
            age: 0
        };

        UserServices.GetUserInfo()
                    .then(function (response) {
                        User = response;
                        $scope.User = User;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });

    };

    UserController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'UserServices'];

})();