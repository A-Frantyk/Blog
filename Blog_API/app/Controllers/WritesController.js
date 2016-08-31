(function () {
	'use strict'

	angular.module('myApp')
           .controller('WritesController', WritesController);

	function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic, IndexServices) {

		var currentTopicName = $('.active').children('a').text();

		var likes = [{}];

		var Writes = [{
		}];

		$scope.current_Topic = localStorage.getItem(currentTopicName);
		$scope.isCollapsed = true;
		$scope.totalItems = 15;


		$scope.$watch(function () {
			return ShareTopic.getTopicId();
		},function (value) {
            WriteServices.GetWritesByTopic(value)
						 .then(function (response) {
						 	Writes = response;

						 	$scope.Writes = Writes;
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

	WritesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices', 'TopicServices', 'ShareTopic', 'IndexServices'];
})();