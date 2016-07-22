(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router', 'ngDialog', 'ngRoute', 'ngResource','ui.bootstrap', 'CONST']);

    myApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            redirectTo: '/Home',
            data: {
                privateData: true
            }
        })
        .when('/Home', {
            template: 'Views/Home.html',
            controller: 'IndexController',
            data: {
                privateData: true
            }
        })

        .when('/write/all', {
            template: 'View/'
        })



    }]);

    myApp.value('ServerURL', 'http://localhost:51393/');

})();
