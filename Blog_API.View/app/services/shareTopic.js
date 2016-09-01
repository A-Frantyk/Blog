(function () {
	'use strict'

	angular.module('appView')
           .service('shareTopic', shareTopic);

	function shareTopic() {
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