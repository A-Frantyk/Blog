(function () {
    'use strict'

    angular.module("myApp")
           .service("authService", authService);

    function authService($http, $q, localStorageService) {
        var serviceBase = 'http://localhost:51393/';

        var authServiceFactory = {};

        var _authentification = {
            isAuth: false,
            userName: ""
        };

        var _saveRegistration = function (registration) {

            _logOut();

            return $http.post(serviceBase + "api/account/register", registration)
                        .then(function (response) {
                            return response;
                        });
        };


        var _login = function (loginData) {
            var data = "grant_type=password&userName=" + loginData.userName + "&password=" + loginData.password;

            var deferred = $q.defer();

            $http.post(serviceBase + "oauth/token",
                       data,
                       {
                           headers: {
                               'Content-Type': 'application/x-www-form-urlencoded'
                           }
                       })
                 .success(function (response) {
                     localStorageService.set('authorizationData',
                                             {
                                                 token: response.access_token,
                                                 userName: loginData.userName
                                             });

                     _authentification.isAuth = true;
                     _authentification.userName = loginData.userName;

                     deferred.resolve(response);

                 })
                .error(function (err, status) {
                    _logOut();
                    deferred.reject(err);
                });

            return deferred.promise;
        };

        var _logOut = function () {
            console.log("authService: " + localStorageService.get('authorizationData'));

            localStorageService.remove('authorizationData');

            _authentification.isAuth = false;
            _authentification.userName = "";
        };

        var _fillAuthData = function () {
            var authData = localStorageService.get('authorizationData');
            if (authData) {
                _authentification.isAuth = true;
                _authentification.userName = authData.userName;
            }

        }


        authServiceFactory.saveRegistration = _saveRegistration;
        authServiceFactory.login = _login;
        authServiceFactory.logOut = _logOut;
        authServiceFactory.fillAuthData = _fillAuthData;
        authServiceFactory.authentification = _authentification;

        return authServiceFactory;
    };

    authService.$inject = ['$http', '$q', 'localStorageService'];
})();
(function () {
	'use strict'

	angular.module("myApp")
		   .service("CommentsService", CommentsService);

	function CommentsService($q, HttpFactory, API_URL) {

		this.GetAllComments = function () {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetComments, deferred);

			return deferred.promise;
		}

		this.GetCommentsByWrite = function (writeId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetCommentByWriteId + writeId, deferred);

			return deferred.promise;
		}

	};

	CommentsService.$inject = [];
})();
(function () {
    'use strict'

    angular.module('myApp')
           .service('HomeServices', HomeServices);

    function HomeServices($q, HttpFactory, API_URL) {

        this.GetFullBlogInfo = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Blog, deffered);

            return deffered.promise;
        }

        this.GetBlogTitle = function () {
            var deffered = $q.defer();

            HttpFactory.getAsync(API_URL.GetTitle, deffered);

            return deffered.promise;
        }

        //this.GetBlogAuthor = function () {
        //    var deffered = $q.defer();
        //    var ddeff = $q.defer();
        //    HttpFactory.getAsync(API_URL.GetAuthor, ddeff);
        //    HttpFactory.getAsync(API_URL.GetUserByID + authorId, deffered);

        //    return deffered.promise.name + ' ' + deffered.promise.last_Name;
        //}

        this.GetBlogDescription = function () {
            var deffered = $q.defer();

            HttpFactory.getAsync(API_URL.GetDescription, deffered);

            return deffered.promise;
        }
    };

    HomeServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();
(function () {
    'use strict'

    angular.module('myApp')
           .factory('HttpFactory', HttpFactory);

    function HttpFactory($http, $q) {
        var promise;
        var topic = {
            topic_Id: 0,
            topicT_itle: null
        };

        return {
            getAsync: function (url, deferred) {
                $http.get(url)
                     .success(function (response) {
                         deferred.resolve(response);
                     })

                     .error(function (error) {
                         deferred.reject(error);
                     });
            },
            postAsync: function (url, item, deferred) {
                $http.post(url, item)
                     .success(function (response) {
                         deferred.resolve(response);
                     })
                     .error(function (error) {
                         deffered.reject(error);
                     });
            },
            deleteAsync: function (url, item, deferred) {
                $http.delete(url)
                     .success(function (response) {
                         deferred.resolve(response);
                     })
                     .error(function (error) {
                         deferred.reject(error);
                     });
            },
            putAsync: function (url, item, deferred) {
                $http.put(url, item)
                     .success(function (response) {
                         deferred.resolve(response);
                     })
                     .error(function (error) {
                         deferred.reject(error);
                     });
            }
        };
    };

    HttpFactory.$inject = ['$http', '$q'];
})();
(function () {
    'use strict'

    angular.module('myApp')
           .service('IndexServices', IndexServices);
    function IndexServices($q, HttpFactory, API_URL) {

        this.GetUserInfo = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetUserByID + 1, deffered);

            return deffered.promise;
        }

        this.GetUserByID = function (id) {
            var deffer = $q.defer();
            HttpFactory.getAsync(API_URL.GetUserByID + id, deffer);

            return deffer.promise;
        }
    };

    IndexServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();
(function () {
	'use strict'

	angular.module("myApp")
		   .service("LikesService", LikesService);

	function LikesService($q, HttpFactory, API_URL) {
		this.GetAllLikes = function () {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikes, deferred);

			return deferred.promise;
		}

		this.GetLikesByWrite = function (writeId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikesByWriteId + writeId, deferred);

			return deferred.promise;
		}

		this.GetLikeByComment = function (commentId) {
			var deferred = $q.defer();

			HttpFactory.getAsync(API_URL.GetLikesByComment + commentId, deferred);

			return deferred.promise;
		}
	};

	LikesService.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();
(function () {
    'use strict'

    angular.module('myApp')
           .service('LoginServices', LoginServices);

    function LoginServices() {

    };

    LoginServices.$inject = [];
})();
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
//(function () {
//    'use strict'

//    angular.module("myApp")
//           .service("UserService", UserService);

//    function UserService($q, HttpFactory, API_URL) {

//        this.GetUser = function () {

//        }

//    };

//    UserSerivce.$inject = [];
//})();
(function () {
    'use strict'

    angular.module('myApp')
           .service('WriteServices', WriteServices);

    function WriteServices($q, HttpFactory, API_URL) {

        this.GetAllWrites = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Writes, deffered);

            return deffered.promise;
        }

        this.GetWritesByTopic = function (topicId) {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetWritesByTopicID + topicId, deffered);

            return deffered.promise;
        }

        this.GetWritesTitle = function (topicId) {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.AllWritesTitle + topicId, deffered);

            return deffered.promise;
        }

        this.GetWriteBody = function (writeId) {
            var deferred = $q.defer();
            HttpFactory.getAsync(API_URL.WriteBody + writeId, deferred);

            return deferred.promise;
        }
    };

    WriteServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();