(function () {
	angular.module('CONST', [])
            .constant('API_URL', {

                Writes: 'http://localhost:80/api/write/all/',
                GetWritesByID: 'http://localhost:80/api/write/',
                GetWritesByTopicID: 'http://localhost:80/api/write/getbytopicId/',
                EditWrite: 'http://localhost:80/api/write/edit',
                AddWrite: 'http://localhost:80/api/write/add',
                WriteBody: 'http://localhost:80/api/write/body/',
                AllWritesTitle: 'http://localhost:80/api/write/allWrites/',

                Topics: 'http://localhost:80/api/topic/all',
                GetTopicByID: 'http://localhost:80/api/topic/',
                AddTopic: 'http://localhost:80/api/topic/add',
                EditTopic: 'http://localhost:80/api/topic/edit',

                Users: 'http://localhost:80/api/user/all',
                GetUserByID: 'http://localhost:80/api/user/',
                AddUser: 'http://localhost:80/api/user/add',
                EditUser: 'http://localhost:80/api/user/edit',

                Blog: 'http://localhost:80/api/blog/all',
                GetBlogByID: 'http://localhost:80/api/blog/',
                EditBlog: 'http://localhost:80/api/blog/edit',
                GetTitle: 'http://localhost:80/api/blog/title',
                GetAuthor: 'http://localhost:80/api/blog/author',
                GetDescription: 'http://localhost:80/api/blog/description',

                GetComments: 'http://localhost:80/api/comment/all',
                GetCommentById: 'http://localhost:80/api/comment/',
                GetCommentByWriteId: 'http://localhost:80/api/comment/byWriteId/',
                EditComment: 'http://localhost:80/api/comment/edit',
                AddComment: 'http://localhost:80/api/comment/add'
            });
})();