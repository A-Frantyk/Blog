(function () {
    'use strict'

    angular.module('myApp')
           .service('TopicServices', TopicServices);

    function TopicServices($q, HttpFactory, API_URL) {
        this.GetTopics = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Topics, deffered);

            return deffered.promise;
        }

        this.GetTopicById = function (id) {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetTopicByID + id, deffered);

            return deffered.promise;
        }
    };

    TopicServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();