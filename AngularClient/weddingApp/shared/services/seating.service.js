(function () {
    'use strict';

    angular.module("app.seating").factory("SeatingService", SeatingService);

    SeatingService.$inject = ['$http'];

    function SeatingService($http) {

        var serviceBase = "http://localhost:60472/";
        var SeatingServiceFactory = {};

        var getSeatingData = function () {
            return $http.get(serviceBase + 'api/seating/get')
                .then(function (seating) {
                    return seating;
                });
        }

        SeatingServiceFactory.getSeatingData = getSeatingData;

        return SeatingServiceFactory;
    }
})()