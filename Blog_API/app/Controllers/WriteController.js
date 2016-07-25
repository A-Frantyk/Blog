(function () {
    'use strict'

    angular.module('myApp')
           .controller('WritesController', WritesController);

    function WritesController($http, $q, $stateParams, HttpFactory, API_URL, WriteServices) {
        
    }

    WritesController.$inject = ['$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices'];
})();