(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router', 'ngDialog', 'ngRoute', 'ngResource','ui.bootstrap', 'CONST', 'ngAnimate', 'LocalStorageModule']);

    myApp.config(['$routeProvider','$locationProvider', function ($routeProvider,$locationProvider) {
        $routeProvider
            .when('/', {
                redirectTo: '/Home',
                data: {
                    privateData: true
                }
            })
        .when('/Home', {
            templateUrl: '/Views/Home.html',
            controller: 'HomeController',
            data: {
                privateData: true
            }
        })

        .when('/write/all', {
            templateUrl: '/Views/Writes.html',
            controller: 'WritesController',
            data: {
                privateData: true
            }
        })

        .when('/login', {
            templateUrl: "/Views/LogIn_Form.html",
            controller: "LoginController"
        });

        //$locationProvider.html5Mode(true);
    }]);

    myApp.config(['$httpProvider', function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptorFactory');
    }]);

    myApp.run(['authService', function (authService) {
        authService.fillAuthData();
    }]);

    //myApp.value('ServerURL', 'http://localhost:51393/');

})();
