(function () {
    'use strict';

    angular.module('weddingApp').config(function ($routeProvider) {

        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: 'weddingApp/home/home.template.html',
                controller: 'HomeController'
            })

            // route for the about page
            .when('/movies', {
                templateUrl: 'weddingApp/movies/movies.template.html',
                controller: 'MoviesController as vm'
            })

            // route for the contact page
            .when('/bootstrapTutorial', {
                templateUrl: 'weddingApp/bootstrapTutorial/bootstrapTutorial.template.html',
                controller: 'BootstrapTutorialController'
            });
    })


})();