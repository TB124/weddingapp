﻿(function () {
    'use strict';

    angular.module('app.register')
        .run(registerRoute);

    registerRoute.$inject = ['routerHelper'];

    function registerRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'register',
                config: {
                    url: '/register',
                    parent: 'public',
                    title: 'Register',
                    views: {
                        'public-view': {
                            templateUrl: 'weddingApp/register/register.template.html',
                            controller: 'RegisterController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();