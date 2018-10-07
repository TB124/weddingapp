(function ready() {
    'use strict';

    angular.module('weddingApp', [
        'app.core',
        'app.landing',
        'app.register',
        'app.login',
        'app.home',
        'app.tables',
        'app.persons',
        'app.seating',
        'app.personGroups',
        'app.directives'
    ]);

    angular.bootstrap(document, ['weddingApp']);

})();