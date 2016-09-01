(function () {
	'use strict'

	angular.module('appView')
           .service('topicServices', topicServices);

	function topicServices($q, httpFactory, API_URL) {
		this.GetTopics = function () {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.Topics, deffered);

			return deffered.promise;
		}

		this.GetTopicById = function (id) {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.GetTopicByID + id, deffered);

			return deffered.promise;
		}
	};

	topicServices.$inject = ['$q', 'httpFactory', 'API_URL'];
})();