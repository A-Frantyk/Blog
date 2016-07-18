(function () {
    'use strict'

    angular.module('myApp')
           .controller('UserController', function UserController($scope, $http, $q, $stateParams, HttpFactory, API_URL, UserServices) {
               //console.dir(UserServices.GetUserInfo());

               //var vm = this;

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

               $scope.User;

               UserServices.GetUserInfo()
                           .then(function (response) {
                               User = response;
                               console.log(User);
                               $scope.User = User;
                           })
                           .catch(function (error) {
                               console.log(error);
                           });

           });

    //UserController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'UserServices'];


})();