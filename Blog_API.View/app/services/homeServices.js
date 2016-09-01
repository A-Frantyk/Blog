(function () {
	'use strict'

	angular.module('appView')
           .service('homeServices', homeServices);

	function homeServices($q, httpFactory, API_URL) {

		this.GetFullBlogInfo = function () {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.Blog, deffered);

			return deffered.promise;
		}

		this.GetBlogTitle = function () {
			var deffered = $q.defer();

			httpFactory.getAsync(API_URL.GetTitle, deffered);

			return deffered.promise;
		}

		//this.GetBlogAuthor = function () {
		//    var deffered = $q.defer();
		//    var ddeff = $q.defer();
		//    HttpFactory.getAsync(API_URL.GetAuthor, ddeff);
		//    HttpFactory.getAsync(API_URL.GetUserByID + authorId, deffered);

		//    return deffered.promise.name + ' ' + deffered.promise.last_Name;
		//}

		this.GetBlogDescription = function () {
			var deffered = $q.defer();

			httpFactory.getAsync(API_URL.GetDescription, deffered);

			return deffered.promise;
		}
	};

	homeServices.$inject = ['$q', 'httpFactory', 'API_URL'];
})();