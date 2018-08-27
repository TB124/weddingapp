(function () {
    'use strict';

    angular.module('app.persons')
        .run(personRoute);

    personRoute.$inject = ['routerHelper'];

    function personRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'persons',
                config: {
                    url: '/persons',
                    parent: 'private',
                    title: 'Persons',
                    views: {
                        'main-content': {
                            templateUrl: 'weddingApp/persons/persons.template.html',
                            controller: 'PersonsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();