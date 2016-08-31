(function () {
	'use strict'

	angular.module("CONST")
		   .service("getApiServiceUrl", getApiServiceUrl);

	function getApiServiceUrl($location) {
		this.getHost = function () {
			var host = $location.host();

			return host;
		}

		this.getPort = function () {
			var port = $location.port();

			return port;
		}
	};

	getApiServiceUrl.$inject = ['$location'];
})();