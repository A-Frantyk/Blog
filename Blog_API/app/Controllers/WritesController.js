(function () {
	'use strict'

	angular.module('myApp')
           .controller('WritesController', WritesController);

	function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic, IndexServices, LikesService) {

		var currentTopicName = $('.active').children('a').text();

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

		var writesAuthors = [{
			user_Number: 0,
			author_Name: null,
			author_LastName: null,
		}];

		var likes = [{
			write_Number: 0,
			like: 0
		}];

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
									 	console.log(Writes);

									 	for (var i = 0; i < response.length; i++) {
									 		IndexServices.GetUserByID(response[i].author)
														 .then(function (response) {
														 	writesAuthors.push(response);
														 })
														 .catch(function (err) {
														 	console.log(err);
														 });
									 		LikesService.GetLikesByWrite(response[i].write_Number)
														.then(function (response) {
															if (response !== null) {
																likes.push(response.like);
															}
														})
													     .catch(function (err) {
													     	console.log(err);
													     });
									 	};
									 	
									 	//var obj = _.mergeWith(Writes, writesAuthors, function (objValue, srcValue) {
									 	//	if (_.isArray(objValue)) {
									 	//		return objValue.concat(srcValue);
									 	//	}
									 	//});

									 	console.log(writesAuthors);

									 	for (var i = 0; i < Writes.length; i++) {

									 		var author = Writes[i].author;

									 		var name = "author_Name";
									 		var last_Name = "author_LastName";

									 		for (var j = 0; j < writesAuthors.length; j++) {
									 			var authorNum = writesAuthors[j].user_Number;
									 			console.log("Author_us: " + authorNum);

									 			if (authorNum !== null && author === authorNum) {
									 				Writes[i].author_Name = writesAuthors[j].author_Name;
									 				Writes[i].author_LastName = writesAuthors[j].author_LastName;
									 			}
									 		}
									 	}

									 	$scope.Writes = Writes;
									 	console.dir("Writes: ");
									 	console.dir(Writes);
									 	$scope.writesAuthors = writesAuthors;
									 	$scope.likes = likes;

									 })
										.catch(function (error) {
											console.log(error);
										});

                      	WriteServices.GetWritesTitle(value)
									 .then(function (response) {
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