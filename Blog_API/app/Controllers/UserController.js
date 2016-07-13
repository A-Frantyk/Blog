(function () {
    'use strict'

    angular.module('app')
           .controller('UserController', ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URLS', 'UserServices']);

    UserController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URLS', 'UserServices'];

    function UserController($scope, $http, $q, $stateParams, HttpFactory, API_URLS, UserServices) {
        //var vm = this;

        this.Users = [];

        this.User = {
            userName        : null,
            lastName        : null,
            userInfo        : null,
            userID          : 0,
            education       : null,
            mobPhone        : 0,
            facebookLink    : null,
            vkLink          : null,
            mailLink        : null
        };

        UserServices.GetUserByID($stateParams.ID)
                    .then(function (response) {
                        User = response;
                    })
                    .catch(function (error) {
                        console.log(error);
                    });
    }
})