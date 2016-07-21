(function () {
    'use strict'

    angular.module('myApp')
           .controller('IndexController', IndexController);

    function IndexController($scope, $http, $q, HttpFactory, API_URL, IndexServices) {
        
        this.Blog = {
            title: null,
            author: null,
            description: null
        }

        IndexServices.GetBlogTitle()
                     .then(function (response) {
                         Blog.title = response;
                     })
                     .catch(function (error) {
                         this.error = error;
                     });

        IndexServices.GetBlogAuthor()
                     .then(function (response) {
                         Blog.author = response;
                     })
                     .catch(function (error) {
                         this.error = error;
                     });

        IndexServices.GetBlogDescription()
                     .then(function (response) {
                         Blog.description = response;
                     })
                     .catch(function (error) {
                         this.error = error;
                     })

    };

    IndexController.$inject = ['$scope', '$http', '$q', 'HttpFactory', 'API_URL', 'IndexServices'];
})();