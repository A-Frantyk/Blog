(function () {
    'use strict'

    angular.module('myApp')
           .services('IndexServices', IndexServices);

    function IndexServices($q, HttpFactory, API_URL) {

        this.GetFullBlogInfo = function () {
            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.Blog, deffered);

            return deffered.promise;
        }

        this.GetBlogTitle = function () {
            return this.GetFullBlogInfo().title;
        }

        this.GetBlogAuthor = function () {
            var authorId = this.GetFullBlogInfo().author;

            var deffered = $q.defer();
            HttpFactory.getAsync(API_URL.GetUserByID + authorId, deffered);

            return deffered.promise.name + ' ' + deffered.promise.last_Name;
        }

        this.GetBlogDescription = function () {
            return this.GetFullBlogInfo().description;
        }
    };

    IndexServices.$inject = ['$q', 'HttpFactory', 'API_URL'];
})();