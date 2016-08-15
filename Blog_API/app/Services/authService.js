(function () {
    'use strict'

    angular.module("myApp")
           .service("authService", authService);

    function authService($http, $q, localStorageService) {
        var serviceBase = 'http://localhost:51393/';

        var authServiceFactory = {};

        var _authentification = {
            isAuth: false,
            userName: ""
        };

        var _saveRegistration = function (registration) {

            _logOut();

            return $http.post(serviceBase + "api/account/register", registration)
                        .then(function (response) {
                            return response;
                        });
        };


        var _login = function (loginData) {
            var data = "grant_type=password&userName=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post(serviceBase + "oauth/token",
                       data,
                       {
                           headers: {
                               'Content-Type': 'application/x-www-form-urlencoded'
                           }
                       })
                 .success(function (response) {
                     localStorageService.set('authorizationData',
                                             {
                                                 token: response.access_token,
                                                 userName: loginData.userName
                                             });

                     _authentification.isAuth = true;
                     _authentification.userName = loginData.userName;

                     deferred.resolve(response);

                 })
                .error(function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var _logOut = function () {
            console.log("authService: " + localStorageService.get('authorizationData'));

            localStorageService.remove('authorizationData');

            _authentification.isAuth = false;
            _authentification.userName = "";
        };

        var _fillAuthData = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentification.isAuth = true;
                _authentification.userName = authData.userName;
            }

        }


        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentification = _authentification;

        return authServiceFactory;
    };

    authService.$inject = ['$http', '$q', 'localStorageService'];
})();