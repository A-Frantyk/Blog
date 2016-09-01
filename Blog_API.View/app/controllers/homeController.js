(function () {
	'use strict'

	angular.module('appView')
           .controller('homeController', homeController);

	function homeController($scope, $http, $q, $stateParams, httpFactory, API_URL, homeServices) {

		$scope.Blog;

		$scope.title;
		$scope.author;
		$scope.description;

		var Blog = Blog = {
			title: null,
			author: null,
			description: null
		};

		//IndexServices.GetFullBlogInfo()
		//             .then(function (response) {
		//                 console.log(response);

		//                 Blog = response;
		//                 $scope.Blog = Blog;
		//             })
		//             .catch(function (error) {
		//                 console.log(error);
		//             });

		homeServices.GetBlogTitle()
                     .then(function (response) {
                     	//console.log(response);
                     	Blog.title = response;
                     	$scope.title = response;
                     });

		//IndexServices.GetBlogAuthor()
		//             .then(function (response) {
		//                 console.log(response);
		//                 Blog.author = response;
		//             })
		//             .catch(function (error) {
		//                 this.error = error;
		//             });

		homeServices.GetBlogDescription()
                     .then(function (response) {
                     	//console.log(response);
                     	Blog.description = response;
                     	$scope.description = response;
                     });

	};

	homeController.$inject = ['$scope', '$http', '$q', '$stateParams', 'httpFactory', 'API_URL', 'homeServices'];
})();