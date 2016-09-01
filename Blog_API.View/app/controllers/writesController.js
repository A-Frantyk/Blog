(function () {
	'use strict'

	angular.module('appView')
           .controller('writesController', writesController);

	function writesController($scope, $http, $q, $stateParams, httpFactory, API_URL, writeServices, topicServices, shareTopic, indexServices) {

		var currentTopicName = $('.active').children('a').text();

		var likes = [{}];

		var Writes = [{
		}];

		$scope.current_Topic = localStorage.getItem(currentTopicName);
		$scope.isCollapsed = true;
		$scope.totalItems = 15;


		$scope.$watch(function () {
			return shareTopic.getTopicId();
		}, function (value) {
			writeServices.GetWritesByTopic(value)
						 .then(function (response) {
						 	Writes = response;

						 	$scope.Writes = Writes;
						 })
						 .catch(function (error) {
						 	console.log(error);
						 });

			topicServices.GetTopicById(value)
						 .then(function (response) {
						 	$scope.currentTopicName = response.topic_Title;
						 })
							.catch(function (error) {
								console.log(error);
							});

			topicServices.GetTopicById(value)
						 .then(function (response) {
						 	$scope.currentTopicDescription = response.description;
						 })
						 .catch(function (error) {
						 	console.log(error);
						 });

		}, true);

	};

	writesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'httpFactory', 'API_URL', 'writeServices', 'topicServices', 'shareTopic', 'indexServices'];
})();