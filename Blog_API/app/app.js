(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router','ngDialog', 'ngRoute' ,'ngResource', 'CONST']);



    //myApp.config(['$stateProvider', '$urlRouteProvider', function ($stateProvider, $urlRouteProvider) {

    //    $urlRouteProvider.otherwise('Home');

    //    $stateProvider
    //                .state('Home', {
    //                    url: '/Home',
    //                    templateUrl: '/Home',
    //                    controller: HomeController
    //                })
    //                .state('User', {
    //                    url: '/Home/User',
    //                    templateUrl: 'Home/User',
    //                    controller: UserController
    //                });

    //}]);
    //myApp.value('ServerURL', 'http://localhost:51393/');

})();
