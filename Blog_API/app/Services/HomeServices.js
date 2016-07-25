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