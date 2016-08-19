(function () {
	'use strict'

	angular.module('myApp')
           .controller('WritesController', WritesController);

	function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic, IndexServices, LikesService) {

		var currentTopicName = $('.active').children('a').text();

		var likes = [{}];

		var Writes = [{
			write_Number: 0,
			topic_Number: 0,
			title: null,
			description: null,
			author: 0,
			date: null,
			time: null,
			author_Name: null,
			author_LastName: null
		}];

		$scope.current_Topic = localStorage.getItem(currentTopicName);
		$scope.isCollapsed = true;
		$scope.totalItems = 15;


		$scope.$watch(function () {
			return ShareTopic.getTopicId();
		},function (value) {
			var writesAuthors = [{ user_Number: 0 }];

            WriteServices.GetWritesByTopic(value)
						 .then(function (response) {
						 	Writes = response;

						 	$scope.Writes = Writes;
						 	$scope.writesAuthors = writesAuthors;
						 	$scope.likes = likes;
						 })
						 .catch(function (error) {
							console.log(error);
						 });

            TopicServices.GetTopicById(value)
						 .then(function (response) {
							$scope.currentTopicName = response.topic_Title;
						 })
							.catch(function (error) {
						 console.log(error);
						 });

            TopicServices.GetTopicById(value)
						 .then(function (response) {
							$scope.currentTopicDescription = response.description;
						 })
						 .catch(function (error) {
							console.log(error);
						 });

        }, true);

	};

	WritesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices', 'TopicServices', 'ShareTopic', 'IndexServices', 'LikesService'];
})();