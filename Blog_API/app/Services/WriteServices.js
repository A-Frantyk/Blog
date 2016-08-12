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
            HttpFactory.getAsync(API_URL.AllWritesTitle + topicId, deffered);

            return deffered.promise;
        }

        this.GetWriteBody = function (writeId) {
            var deferred = $q.defer();
            HttpFactory.getAsync(API_URL.WriteBody + writeId, deferred);

            return deferred.promise;
        }
    };

    WriteServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();