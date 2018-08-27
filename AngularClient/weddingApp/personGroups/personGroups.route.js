(function () {
    'use strict';

    angular.module('app.personGroups')
        .run(personGroupRoute);

    personGroupRoute.$inject = ['routerHelper'];

    function personGroupRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'personGroups',
                config: {
                    url: '/personGroups',
                    parent: 'private',
                    title: 'PersonGroups',
                    views: {
                        'main-content': {
                            templateUrl: 'weddingApp/personGroups/personGroups.template.html',
                            controller: 'PersonGroupsController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();