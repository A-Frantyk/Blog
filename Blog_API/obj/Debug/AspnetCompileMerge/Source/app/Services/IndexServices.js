(function () {
    'use strict'

    angular.module('myApp')
           .service('IndexServices', IndexServices);
    function IndexServices($q, HttpFactory, API_URL) {

        this.GetUserInfo = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetUserByID + 1, deffered);

            return deffered.promise;
        }

        this.GetUserByID = function (id) {
            var deffer = $q.defer();
            HttpFactory.getAsync(API_URL.GetUserByID + id, deffer);

            return deffer.promise;
        }
    };

    IndexServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();