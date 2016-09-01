(function () {
	angular.module('CONST', [])
            .constant('API_URL', {

            	Writes: 'http://localhost:51393/api/write/all/',
            	GetWritesByID: 'http://localhost:51393/api/write/',
            	GetWritesByTopicID: 'http://localhost:51393/api/write/getbytopicId/',
            	WriteBody: 'http://localhost:51393/api/write/body/',
            	AllWritesTitle: 'http://localhost:51393/api/write/allWrites/',

            	Topics: 'http://localhost:51393/api/topic/all',
            	GetTopicByID: 'http://localhost:51393/api/topic/',

            	Users: 'http://localhost:51393/api/user/all',
            	GetUserByID: 'http://localhost:51393/api/user/',

            	Blog: 'http://localhost:51393/api/blog/all',
            	GetBlogByID: 'http://localhost:51393/api/blog/',
            	GetTitle: 'http://localhost:51393/api/blog/title',
            	GetAuthor: 'http://localhost:51393/api/blog/author',
            	GetDescription: 'http://localhost:51393/api/blog/description',

            	GetComments: 'http://localhost:51393/api/comment/all',
            	GetCommentById: 'http://localhost:51393/api/comment/',
            	GetCommentByWriteId: 'http://localhost:51393/api/comment/byWriteId/',
            	EditComment: 'http://localhost:51393/api/comment/edit',
            	AddComment: 'http://localhost:51393/api/comment/add'
            });
})();