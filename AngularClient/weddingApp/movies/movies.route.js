﻿(function () {
    'use strict';

    angular.module('app.movies')
        .run(movieRoute);

    movieRoute.$inject = ['routerHelper'];

    function movieRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'movies',
                config: {
                    url: '/movies',
                    parent: 'private',
                    title: 'Movies',
                    views: {
                        'main-content': {
                            templateUrl: 'weddingApp/movies/movies.template.html',
                            controller: 'MoviesController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();