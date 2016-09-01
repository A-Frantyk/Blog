(function () {
	'use strict'

	angular.module('appView')
           .controller('indexController', indexController);
	function indexController($scope, $http, $q, $stateParams, $location, httpFactory, API_URL, indexServices, topicServices, shareTopic) {
		$scope.User;
		$scope.Topics = [];
		$scope.getUserId = function () {
			return User.user_Number;
		};

		$scope.Topic = shareTopic;

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

		//$scope.loginData = {
		//	userName: "",
		//	password: ""
		//};

		//$scope.message = "";

		//$scope.login = function () {
		//	authService.login($scope.loginData)
        //               .then(function (response) {
        //               	$location.path('/');
        //               },
        //               function (error) {
        //               	$scope.message = error.error_description;
        //               });
		//};

		//$scope.logOut = function () {
		//	authService.logOut();
		//	$location.path('/Home');
		//};

		//$scope.authentication = authService.authentification;


		/********************************************/

		indexServices.GetUserInfo()
                     .then(function (response) {
                     	User = response;
                     	//console.log(User);
                     	$scope.User = User;
                     })
                     .catch(function (error) {
                     	console.log(error);
                     });

		topicServices.GetTopics()
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

			shareTopic.setTopicId(id);
		};

		$scope.setCurrentTopic = function (topic) {
			$scope.Topic = topic;
		}
	};

	indexController.$inject = ['$scope', '$http', '$q', '$stateParams', '$location', 'httpFactory', 'API_URL', 'indexServices', 'topicServices', 'shareTopic'];

})();