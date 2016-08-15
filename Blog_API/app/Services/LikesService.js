(function () {
	'use strict'

	angular.module("myApp")
		   .service("LikesService", LikesService);

	function LikesService($q, HttpFactory, API_URL) {
		this.GetAllLikes = function () {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikes, deferred);

			return deferred.promise;
		}

		this.GetLikesByWrite = function (writeId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikesByWriteId + writeId, deferred);

			return deferred.promise;
		}

		this.GetLikeByComment = function (commentId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikesByComment + commentId, deferred);

			return deferred.promise;
		}
	};

	LikesService.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();