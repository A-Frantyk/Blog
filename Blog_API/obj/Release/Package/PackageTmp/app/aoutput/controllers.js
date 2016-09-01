(function () {
    'use strict'

    angular.module('myApp')
           .controller('HomeController', HomeController);

    function HomeController($scope, $http, $q, $stateParams, HttpFactory, API_URL, HomeServices) {
        
        $scope.Blog;

        $scope.title;
        $scope.author;
        $scope.description;

        var Blog = Blog = {
            title: null,
            author: null,
            description: null
        };

        //IndexServices.GetFullBlogInfo()
        //             .then(function (response) {
        //                 console.log(response);

        //                 Blog = response;
        //                 $scope.Blog = Blog;
        //             })
        //             .catch(function (error) {
        //                 console.log(error);
        //             });

        HomeServices.GetBlogTitle()
                     .then(function (response) {
                         //console.log(response);
                         Blog.title = response;
                         $scope.title = response;
                     });

        //IndexServices.GetBlogAuthor()
        //             .then(function (response) {
        //                 console.log(response);
        //                 Blog.author = response;
        //             })
        //             .catch(function (error) {
        //                 this.error = error;
        //             });

        HomeServices.GetBlogDescription()
                     .then(function (response) {
                         //console.log(response);
                         Blog.description = response;
                         $scope.description = response;
                     });

    };

    HomeController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'HomeServices'];
})();
(function () {
    'use strict'

    angular.module('myApp')
           .controller('IndexController', IndexController);
    function IndexController($scope, $http, $q, $stateParams, $location, HttpFactory, API_URL, IndexServices, TopicServices, ShareTopic, authService) {
        $scope.User;
        $scope.Topics = [];
        $scope.getUserId = function () {
            return User.user_Number;
        };

        $scope.Topic = ShareTopic;

        var User = {
            name: null,
            last_Name: null,
            short_Information: null,
            user_Number: 0,
            education: null,
            mobile_Phone: 0,
            facebook_Link: null,
            vk_Link: null,
            mail_Link: null,
            age: 0
        };

        /********* from LoginController *************/
        
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {
            authService.login($scope.loginData)
                       .then(function (response) {
                           $location.path('/');
                       },
                       function (error) {
                           $scope.message = error.error_description;
                       });
        };

        $scope.logOut = function () {
            authService.logOut();
            $location.path('/Home');
        };

        $scope.authentication = authService.authentification;


        /********************************************/

        IndexServices.GetUserInfo()
                     .then(function (response) {
                         User = response;
                         //console.log(User);
                         $scope.User = User;
                     })
                     .catch(function (error) {
                         console.log(error);
                     });

        TopicServices.GetTopics()
                     .then(function (response) {
                         //console.log(response);
                         $scope.Topics = response;
                     })
                     .catch(function (error) {
                         console.log(error);
                     });

        $scope.putTopicInfo = function (title, id) {
            //console.log(localStorage.getItem("Writes"));
            //console.log(title);
            //console.log(id);
            localStorage.setItem(title, id);

            ShareTopic.setTopicId(id);
        };

        $scope.setCurrentTopic = function (topic) {
            $scope.Topic = topic;
        }
    };

    IndexController.$inject = ['$scope', '$http', '$q', '$stateParams', '$location', 'HttpFactory', 'API_URL', 'IndexServices', 'TopicServices', 'ShareTopic', 'authService'];

})();
(function () {
    'use strict'

    angular.module('myApp')
           .controller('LoginController', LoginController);

    function LoginController($scope, $http, HttpFactory, authService) {
        $scope.loginData = {
            userName: "",
            password: ""
        };

        $scope.message = "";

        $scope.login = function () {

            console.log("LoginController tests")

            authService.login($scope.loginData)
                       .then(function (response) {
                           $location.path('/Home');
                       },
                       function (error) {
                           $scope.message = error.error_description;
                       });
        }


        // testing modal approach of login window
        
        $scope.item = item;

        $scope.ok = function () {
            $modalInstance.close();
        };

        $scope.cancel = function () {
            $modalInstance.dismiss('cancel');
        };

        // end testing
    }

    LoginController.$inject = ['$scope', '$http', 'HttpFactory', 'authService'];
})();
(function () {
	'use strict'

	angular.module('myApp')
           .controller('WritesController', WritesController);

	function WritesController($scope, $http, $q, $stateParams, HttpFactory, API_URL, WriteServices, TopicServices, ShareTopic, IndexServices, LikesService) {

		var currentTopicName = $('.active').children('a').text();

		var likes = [{}];

		var Writes = [{
			write_Number: 0,
			topic_Number: 0,
			title: null,
			description: null,
			author: 0,
			date: null,
			time: null,
			author_Name: null,
			author_LastName: null
		}];

		$scope.current_Topic = localStorage.getItem(currentTopicName);
		$scope.isCollapsed = true;
		$scope.totalItems = 15;


		$scope.$watch(function () {
			return ShareTopic.getTopicId();
		},function (value) {
			var writesAuthors = [{ user_Number: 0 }];

            WriteServices.GetWritesByTopic(value)
						 .then(function (response) {
						 	Writes = response;

						 	$scope.Writes = Writes;
						 	$scope.writesAuthors = writesAuthors;
						 	$scope.likes = likes;
						 })
						 .catch(function (error) {
							console.log(error);
						 });

            TopicServices.GetTopicById(value)
						 .then(function (response) {
							$scope.currentTopicName = response.topic_Title;
						 })
							.catch(function (error) {
						 console.log(error);
						 });

            TopicServices.GetTopicById(value)
						 .then(function (response) {
							$scope.currentTopicDescription = response.description;
						 })
						 .catch(function (error) {
							console.log(error);
						 });

        }, true);

	};

	WritesController.$inject = ['$scope', '$http', '$q', '$stateParams', 'HttpFactory', 'API_URL', 'WriteServices', 'TopicServices', 'ShareTopic', 'IndexServices', 'LikesService'];
})();