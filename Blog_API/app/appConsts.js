(function () {
    angular.module('CONST', [])
        .constant('API_URL', {
            Writes: 'http://localhost:51393/api/writes/',
            GetWritesByID: 'http://localhost:51393/api/writes/getwritesbyid/',
            GetWritesByTopicID: 'http://localhost:51393/api/writes/',
            Topics: 'http://localhost:51393/api/topics/',
            GetTopicByID: 'http://localhost:51393/api/topics/gettopicbyid/',
            Users: 'http://localhost:51393/api/user/',
            GetUserByID: 'http://localhost:51393/api/user/'
        });
})();