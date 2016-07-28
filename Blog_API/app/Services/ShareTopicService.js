(function () {
    'use strict'

    angular.module('myApp')
           .service('ShareTopic', ShareTopic);

    function ShareTopic() {
        var Topic = {
            id: 0,
            title: ''
        };

        return Topic;
    }
})();