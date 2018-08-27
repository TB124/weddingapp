(function () {
    'use strict';

    angular.module('weddingApp').config(function ($routeProvider) {

        $routeProvider
            // route for the home page
            .when('/', {
                templateUrl: 'weddingApp/home/home.template.html',
                controller: 'HomeController'
            })

            // route for the table page
            .when('/tables', {
                templateUrl: 'weddingApp/tables/tables.template.html',
                controller: 'TablesController as vm'
            })

            // route for the person page
            .when('/persons', {
                templateUrl: 'weddingApp/persons/persons.template.html',
                controller: 'PersonsController as vm'
            })

            // route for the personGroup page
            .when('/personGroups', {
                templateUrl: 'weddingApp/personGroups/personGroups.template.html',
                controller: 'PersonGroupsController as vm'
            })
    })


})();