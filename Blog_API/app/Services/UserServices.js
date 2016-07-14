(function () {
    'use strict'

    angular.module('myApp')
           .service('UserServices', function UserServices($q, HttpFactory, API_URL) {

               //var a = console.log('dsfsdf');
               this.GetUserInfo = function () {
                       var deffered = $q.defer();
                       HttpFactory.getAsync(API_URL.GetUserByID, deffered);

                       return deffered.promise;
                   };

                   this.GetUserByID = function (id) {
                       var deffer = $q.defer();
                       HttpFactory.getAsync(API_URL.GetUserByID + id, deffer);
                       return deffer.promise;
                   }
                   //return {a:a}

           });

   

    //UserServices.$inject = ['HttpFactory', '$q', 'CONST'];

})();