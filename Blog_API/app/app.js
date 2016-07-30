(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router', 'ngDialog', 'ngRoute', 'ngResource','ui.bootstrap', 'CONST']);

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
        });

        //$locationProvider.html5Mode({
        //    enabled: true
        //});
    }]);

    //myApp.value('ServerURL', 'http://localhost:51393/');

})();
