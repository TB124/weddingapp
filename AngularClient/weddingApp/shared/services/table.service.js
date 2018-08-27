(function () {
    'use strict';

    angular.module("app.tables").factory("TableService", TableService);

    TableService.$inject = ['$http'];

    function TableService($http) {

        var serviceBase = "http://localhost:60472/";
        var TableServiceFactory = {};

        var getTablesData = function () {
            return $http.get(serviceBase + 'api/table/get', {
                skipAuthorization: true
            }).then(function (tables) {
                return tables;
            });
        }
        var addNewTable = function (tableModel) {
            return $http.post(serviceBase + 'api/table/create', tableModel).then(function (newTable) {
                return newTable;
            })
        }
        var updateTable = function (tableModel) {
            return $http.put(serviceBase + 'api/table/update', tableModel).then(function (updatedTable) {
                return updatedTable;
            })
        }
        var deleteTable = function (id) {
            return $http.delete(serviceBase + 'api/table/delete?id=' + id).then(function (deletedTable) {
                return deletedTable;
            });
        }

        TableServiceFactory.getTablesData = getTablesData;
        TableServiceFactory.addNewTable = addNewTable;
        TableServiceFactory.updateTable = updateTable;
        TableServiceFactory.deleteTable = deleteTable;

        return TableServiceFactory;
    }

})()