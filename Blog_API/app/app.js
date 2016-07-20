(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router', 'ngDialog', 'ngRoute', 'ngResource', 'CONST']);

    myApp.config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            redirectTo: '/Index.html',
            data: {
                privateData: true
            }
        })

        .when('/logIn', {
            templateUrl: 'Views/LogIn_Form.html',
            controller: 'LogInController',
            data: {
                privateData: true
            }
        });



    }]);

    myApp.value('ServerURL', 'http://localhost:51393/');

})();
