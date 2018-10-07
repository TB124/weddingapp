(function () {
    'use strict';

    angular.module('app.seating')
        .run(seatingRoute);

    seatingRoute.$inject = ['routerHelper'];

    function seatingRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'seating',
                config: {
                    url: '/seating',
                    parent: 'private',
                    title: 'Seating',
                    views: {
                        'main-content': {
                            templateUrl: 'weddingApp/seating/seating.template.html',
                            controller: 'SeatingController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();