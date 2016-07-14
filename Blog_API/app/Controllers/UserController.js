(function () {
    'use strict'

    angular.module('myApp')
           .controller('UserController', function UserController($scope, $http, $q, $stateParams, HttpFactory, API_URL, UserServices) {
               console.dir(UserServices.GetUserInfo());

                   //var vm = this;

               this.Users = [];

               this.User = {
                       userName: 'Taras',
                       lastName: null,
                       userInfo: null,
                       userID: 0,
                       education: null,
                       mobPhone: 0,
                       facebookLink: null,
                       vkLink: null,
                       mailLink: null
                   };

                   //UserServices.GetUserByID($stateParams.ID)
                   //            .then(function (response) {
                   //                User = response;
                   //            })
                   //            .catch(function (error) {
                   //                console.log(error);
                   //            });

           });

    //UserController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'UserServices'];

    
})();