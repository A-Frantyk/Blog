(function () {
    'use strict'

    var myApp = angular.module('myApp', ['ui.router', 'ngResource', 'CONST']);

    //myApp.service('UserServices', function UserServices($q, HttpFactory, API_URL) {

    //    this.GetUserInfo = function () {
    //        var deffered = $q.defer();
    //        HttpFactory.getAsync(API_URL.GetUserByID, deffered);

    //        return deffered.promise;
    //    };

    //    this.GetUserByID = function (id) {
    //        var deffer = $q.defer();
    //        HttpFactory.getAsync(API_URL.GetUserByID + id, deffer);
    //        return deffer.promise;
    //    }

    //});
    //myApp.config(function ($stateProvider, $urlRouteProvider) {

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

    //});
    myApp.value('ServerURL', 'http://localhost:51393/');




})();
