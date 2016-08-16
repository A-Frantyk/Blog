(function () {
	'use strict'

	angular.module("myApp")
		   .service("CommentsService", CommentsService);

	function CommentsService($q, HttpFactory, API_URL) {

		this.GetAllComments = function () {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetComments, deferred);

			return deferred.promise;
		}

		this.GetCommentsByWrite = function (writeId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetCommentByWriteId + writeId, deferred);

			return deferred.promise;
		}

	};

	CommentsService.$inject = [];
})();