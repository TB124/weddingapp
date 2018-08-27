(function ready() {
    'use strict';


    angular.module('weddingApp', [
        'app.core',
        'app.landing',
        'app.register',
        'app.login',
        'app.home',
        'app.movies',
        'app.directives'
    ]);


    angular.bootstrap(document, ['weddingApp']);


})();