(function () {
    'use strict'

    angular.module('myApp')
           .service('ShareTopic', ShareTopic);

    function ShareTopic() {
        var topicID;
        var topicName;

        return {
            getTopicId: function () {
                return topicID;
            },

            setTopicId: function (id) {
                topicID = id;
            },

            getTopicName: function () {
                return topicName;
            },

            setTopicName: function (name) {
                topicName = name;
            }
        }
    };
})();