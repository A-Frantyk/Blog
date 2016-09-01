(function () {
	'use strict'

	angular.module('appView')
           .service('writeServices', writeServices);

	function writeServices($q, httpFactory, API_URL) {

		this.GetAllWrites = function () {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.Writes, deffered);

			return deffered.promise;
		}

		this.GetWritesByTopic = function (topicId) {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.GetWritesByTopicID + topicId, deffered);

			return deffered.promise;
		}

		this.GetWritesTitle = function (topicId) {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.AllWritesTitle + topicId, deffered);

			return deffered.promise;
		}

		this.GetWriteBody = function (writeId) {
			var deferred = $q.defer();
			httpFactory.getAsync(API_URL.WriteBody + writeId, deferred);

			return deferred.promise;
		}
	};

	writeServices.$inject = ['$q', 'httpFactory', 'API_URL'];
})();