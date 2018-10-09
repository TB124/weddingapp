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
        var addToTable = function (personId, tableId) {
            return $http.post(serviceBase + 'api/seating/addtotable?personId=' + personId + '&tableId=' + tableId).then(function () {
                return true;
            }, function (error) {
                return false;
            });
        }
        var removeFromTable = function (personId) {
            return $http.post(serviceBase + 'api/seating/removefromtable?personId=' + personId).then(function () {
                return true;
            }, function (error) {
                return false;
            });
        }

        SeatingServiceFactory.getSeatingData = getSeatingData;
        SeatingServiceFactory.addToTable = addToTable;
        SeatingServiceFactory.removeFromTable = removeFromTable;

        return SeatingServiceFactory;
    }
})()