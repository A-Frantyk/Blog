(function () {
    'use strict'

    function UserServices($q, HttpFactory, API_URLS) {
        this.GetUserInfo = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URLS.GetUserByID, deffered);

            return deffered.promise;
        };

        this.GetUserByID = function (id) {
            var deffer = $q.defer();
            HttpFactory.getAsync(API_URLS.GetUserByID + id, deffer);
            return deffer.promise;
        }

    }
})