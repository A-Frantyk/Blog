(function () {
	'use strict'

	angular.module('appView')
           .service('indexServices', indexServices);
	function indexServices($q, httpFactory, API_URL) {

		this.GetUserInfo = function () {
			var deffered = $q.defer();
			httpFactory.getAsync(API_URL.GetUserByID + 1, deffered);

			return deffered.promise;
		}

		this.GetUserByID = function (id) {
			var deffer = $q.defer();
			httpFactory.getAsync(API_URL.GetUserByID + id, deffer);

			return deffer.promise;
		}
	};

	indexServices.$inject = ['$q', 'httpFactory', 'API_URL'];
})();