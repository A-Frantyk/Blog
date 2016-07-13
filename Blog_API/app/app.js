(function () {
    'use strict'

    angular.module('app', ['ui-router', 'ngDialog', 'ngResource'])
           .config(function ($stateProvider, $urlRouteProvider) {

               $urlRouteProvider.otherwise('Home');

               $stateProvider
                           .state('Home', {
                               url: '/Home',
                               templateUrl: '/Home',
                               controller: HomeController
                           })
                           .state('User', {
                               url: '/Home/User',
                               templateUrl: 'Home/User',
                               controller: UserController
                           });

           })
           .value('ServerURL', 'http://localhost:51393/')

           // app's constants
           // Available by 'API_URL.NameOfConstant'

           .constant('API_URL', {
               Writes: 'http://localhost:51393/api/writes/',
               GetWritesByID: 'http://localhost:51393/api/writes/getwritesbyid/',
               GetWritesByTopicID: 'http://localhost:51393/api/writes/',
               Topics: 'http://localhost:51393/api/topics/',
               GetTopicByID: 'http://localhost:51393/api/topics/gettopicbyid/',
               Users: 'http://localhost:51393/api/user/',
               GetUserByID: 'http://localhost:51393/api/user/'
           });
})
