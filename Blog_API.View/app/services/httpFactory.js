(function () {
	'use strict'

	angular.module('appView')
           .factory('httpFactory', httpFactory);

	function httpFactory($http, $q) {
		var promise;
		var topic = {
			topic_Id: 0,
			topicT_itle: null
		};

		return {
			getAsync: function (url, deferred) {
				$http.get(url)
                     .success(function (response) {
                     	deferred.resolve(response);
                     })

                     .error(function (error) {
                     	deferred.reject(error);
                     });
			},
			postAsync: function (url, item, deferred) {
				$http.post(url, item)
                     .success(function (response) {
                     	deferred.resolve(response);
                     })
                     .error(function (error) {
                     	deffered.reject(error);
                     });
			},
			deleteAsync: function (url, item, deferred) {
				$http.delete(url)
                     .success(function (response) {
                     	deferred.resolve(response);
                     })
                     .error(function (error) {
                     	deferred.reject(error);
                     });
			},
			putAsync: function (url, item, deferred) {
				$http.put(url, item)
                     .success(function (response) {
                     	deferred.resolve(response);
                     })
                     .error(function (error) {
                     	deferred.reject(error);
                     });
			}
		};
	};

	httpFactory.$inject = ['$http', '$q'];
})();