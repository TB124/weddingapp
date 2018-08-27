(function () {
    'use strict';

    angular.module('app.tables').controller('TablesController', TablesController);

    TablesController.$inject = ['$scope', '$uibModal', 'TableService']

    function TablesController($scope, $uibModal, TableService) {

        var vm = this;
        vm.tables = [];

        vm.getTables = function () {
            TableService.getTablesData().then(function (response) {
                vm.tables = response.data;
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.getTables();

        vm.openDialog = function (table, title) {
            var modalInstance = $uibModal.open({
                templateUrl: 'weddingApp/tables/dialog/tableDialog.template.html',
                controller: 'TableDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    table: function () {
                        return table;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getTables();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.addTable = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editTable = function (table) {
            var title = "Edit"
            vm.openDialog(table, title);
        }

        vm.deleteTable = function (tableId) {
            TableService.deleteTable(tableId).then(function (response) {
                vm.getTables();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
    }
})();