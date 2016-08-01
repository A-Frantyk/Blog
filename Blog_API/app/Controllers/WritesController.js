(function () {
    'use strict'

    angular.module('myApp')
           .controller('WritesController', WritesController);

    function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic) {
        
        var currentTopicName = $('.active').children('a').text();
        $scope.current_Topic = localStorage.getItem(currentTopicName);
        //console.log("Current topic name " + currentTopicName + " and current topic id = " + $scope.current_Topic);

        // Enable panel with some writes collapsed 
        // When page is loaded
        $scope.isCollapsed = true;
        $scope.totalItems = 15;

        //$scope.Topic = ShareTopic;

        WriteServices.GetWritesByTopic($scope.current_Topic)
                     .then(function (response) {
                         //console.log(response);
                         $scope.Writes = response;
                     })
                     .catch(function (error) {
                         //console.log(error);
                     });

        TopicServices.GetTopicById($scope.current_Topic)
                     .then(function (response) {
                         //console.log(response);
                         $scope.currentTopicName = response.topic_Title;
                         $scope.currentTopicDescription = response.description;
                     });
        
        $scope.$watch(function () {
                        return ShareTopic.getTopicId();
        },

                      function (value) {
                        WriteServices.GetWritesByTopic(value)
                                             .then(function (response) {
                                                 //console.log(response);
                                                 $scope.Writes = response;
                                                 //return response;
                                             })
                                             .catch(function (error) {
                                                 console.log(error);
                                             });

                        TopicServices.GetTopicById(value)
                                                       .then(function (response) {
                                                           //console.log(response.topic_Title);
                                                           $scope.currentTopicName = response.topic_Title;
                                                           //return response.topic_Title;
                                                       })
                                                       .catch(function (error) {
                                                           console.log(error);
                                                       });

                        TopicServices.GetTopicById(value)
                                                              .then(function (response) {
                                                                  //console.log(response.description);
                                                                  $scope.currentTopicDescription = response.description;
                                                                  //return response.description;
                                                              })
                                                              .catch(function (error) {
                                                                  console.log(error);
                                                              });
        },true);
    }

    WritesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices', 'TopicServices', 'ShareTopic'];
})();