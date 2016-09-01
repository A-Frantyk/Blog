(function () {
	'use strict'

	var appView = angular.module("appView", ['ui.router', 'ngDialog', 'ngRoute', 'ngResource', 'ui.bootstrap', 'CONST', 'ngAnimate']);

	appView.config(['$routeProvider','$locationProvider', function ($routeProvider,$locationProvider) {
		$routeProvider
            .when('/', {
            	redirectTo: '/home',
            	data: {
            		privateData: true
            	}
            })

        .when('/Home', {
        	templateUrl: '/app/views/home.html',
        	controller: 'homeController',
        	data: {
        		privateData: true
        	}
        })

        .when('/write/all', {
        	templateUrl: '/app/views/writes.html',
        	controller: 'writesController',
        	data: {
        		privateData: true
        	}
        })

        .when('/login', {
        	templateUrl: "/app/views/login.html",
        	controller: "loginController"
        });
	}]);
})();