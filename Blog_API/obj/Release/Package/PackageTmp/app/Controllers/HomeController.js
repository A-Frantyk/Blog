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