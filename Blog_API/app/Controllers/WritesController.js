(function () {
    'use strict'

    angular.module('myApp')
           .controller('WritesController', WritesController);

    function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic) {
        
        var currentTopicName = $('.active').children('a').text();
        var current_Topic = localStorage.getItem(currentTopicName);
        console.log("Current topic name " + currentTopicName + " and current topic id = " + current_Topic);

        $scope.Topic = ShareTopic;
        $scope.isCollapsed = true;

        WriteServices.GetWritesByTopic(current_Topic)
                     .then(function (response) {
                         console.log(response);
                         $scope.Writes = response;
                     })
                     .catch(function (error) {
                         console.log(error);
                     });

        TopicServices.GetTopicById(current_Topic)
                     .then(function (response) {
                         console.log(response);
                         $scope.currentTopicName = response.topic_Title;
                         $scope.currentTopicDescription = response.description;
                     })
    }

    WritesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices', 'TopicServices', 'ShareTopic'];
})();