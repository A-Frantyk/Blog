(function () {
	'use strict'

	angular.module('myApp')
           .controller('WritesController', WritesController);

	function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic, IndexServices, LikesService) {

		var currentTopicName = $('.active').children('a').text();

		var Writes = {
			write_Number: 0,
			topic_Number: 0,
			title: null,
			description: null,
			author: 0,
			date: null,
			time: null,
			author_Name: null,
			author_LastName: null,
			likes: 0
		};

		$scope.current_Topic = localStorage.getItem(currentTopicName);
		$scope.isCollapsed = true;
		$scope.totalItems = 15;
		

		$scope.$watch(function () {
			return ShareTopic.getTopicId();
		},

                      function (value) {
                      	WriteServices.GetWritesByTopic(value)
									 .then(function (response) {


										Writes = response;
										for (var i = 0; i < response.length; i++) {
											 IndexServices.GetUserByID(response[i].author)
											              .then(function (response) {
																 Writes.author_Name = response.name;
																 Writes.author_LastName = response.last_Name
														  })
														  .catch(function (err) {
																 console.log(err);
														  });

											LikesService.GetLikesByWrite(response[i].write_Number)
														 .then(function (response) {
														 	if (response !== null) {
														 		Writes.likes = response.like;
														 	}
														 })
													     .catch(function (err) {
													     	console.log(err);
													     });
										}

										$scope.Writes = Writes;
										
										console.log(Writes);

										})
										.catch(function (error) {
											 	console.log(error);
										});

                      	WriteServices.GetWritesTitle(value)
									 .then(function (response) {
									 	console.log(response);
									 	$scope.WritesTitle = response;
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