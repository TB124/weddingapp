(function () {
    'use strict';

    angular.module('app.tables')
        .run(tableRoute);

    tableRoute.$inject = ['routerHelper'];

    function tableRoute(routerHelper) {
        routerHelper.configureStates(getStates());
    }

    function getStates() {
        return [
            {
                state: 'tables',
                config: {
                    url: '/tables',
                    parent: 'private',
                    title: 'Tables',
                    views: {
                        'main-content': {
                            templateUrl: 'weddingApp/tables/tables.template.html',
                            controller: 'TablesController',
                            controllerAs: 'vm'
                        }
                    }
                }
            }
        ];
    };

})();