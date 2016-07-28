(function () {
    'use strict'

    angular.module('myApp')
           .service('WriteServices', WriteServices);

    function WriteServices($q, HttpFactory, API_URL) {

        this.GetAllWrites = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Writes, deffered);

            return deffered.promise;
        }

        this.GetWritesByTopic = function (topicId) {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetWritesByTopicID + topicId, deffered);

            return deffered.promise;
        }

        this.GetWritesTitle = function (topicId) {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Writes + '/' + topicId, deffered);

            return deffered.promise;
        }
    };

    WriteServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();