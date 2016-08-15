(function () {
    'use strict'

    angular.module('myApp')
           .controller('IndexController', IndexController);
    function IndexController($scope, $http, $q, $stateParams,$location,  HttpFactory, API_URL, IndexServices, TopicServices, ShareTopic, authService) {
        $scope.User;
        $scope.Topics = [];
        $scope.getUserId = function () {
            return User.user_Number;
        };

        $scope.Topic = ShareTopic;

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

        /********* from LoginController *************/
        
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authService.login($scope.loginData)
                       .then(function (response) {
                           $location.path('/');
                       },
                       function (error) {
                           $scope.message = error.error_description;
                       });
        }

        $scope.authentication = authService.authentication;


        /********************************************/

        IndexServices.GetUserInfo()
                     .then(function (response) {
                         User = response;
                         //console.log(User);
                         $scope.User = User;
                     })
                     .catch(function (error) {
                         console.log(error);
                     });

        TopicServices.GetTopics()
                     .then(function (response) {
                         //console.log(response);
                         $scope.Topics = response;
                     })
                     .catch(function (error) {
                         console.log(error);
                     });

        $scope.putTopicInfo = function (title, id) {
            //console.log(localStorage.getItem("Writes"));
            //console.log(title);
            //console.log(id);
            localStorage.setItem(title, id);

            ShareTopic.setTopicId(id);
        };

        $scope.setCurrentTopic = function (topic) {
            $scope.Topic = topic;
        }
    };

    IndexController.$inject = ['$scope', '$http', '$q', '$stateParams', '$location', 'HttpFactory', 'API_URL', 'IndexServices', 'TopicServices', 'ShareTopic', 'authService'];

})();