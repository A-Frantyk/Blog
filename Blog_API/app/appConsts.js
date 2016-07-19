(function () {
    angular.module('CONST', [])
        .constant('API_URL', {
            Writes: 'http://localhost:51393/api/write/',
            GetWritesByID: 'http://localhost:51393/api/write/',
            GetWritesByTopicID: 'http://localhost:51393/api/write/getbytopicId/',
            EditWrite: 'http://localhost:51393/api/write/edit',
            AddWrite: 'http://localhost:51393/api/write/add',
            Topics: 'http://localhost:51393/api/topic/',
            GetTopicByID: 'http://localhost:51393/api/topic/',
            AddTopic: 'http://localhost:51393/api/topic/add',
            EditTopic: 'http://localhost:51393/api/topic/edit',
            Users: 'http://localhost:51393/api/user/',
            GetUserByID: 'http://localhost:51393/api/user/'
        });
})();