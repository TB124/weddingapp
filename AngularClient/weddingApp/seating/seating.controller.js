(function () {
    'use strict';

    angular.module('app.seating').controller('SeatingController', SeatingController);

    SeatingController.$inject = ['$scope', '$uibModal', 'SeatingService', 'PersonService']

    function SeatingController($scope, $uibModal, SeatingService, PersonService) {

        var vm = this;
        vm.seatings = [];
        vm.personsCount = 0;
        vm.personsWithoutTableCount = 0;

        vm.getSeatings = function () {
            SeatingService.getSeatingData().then(function (response) {
                vm.seatings = response.data;
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.getPersonsCount = function () {
            PersonService.getPersonsCount().then(function (result) {
                vm.personsCount = result.data
            }, function (error) {
                // Handle
            });
        }

        vm.getPersonsWithoutTableCount = function () {
            PersonService.getPersonsWithoutTableCount().then(function (result) {
                vm.personsWithoutTableCount = result.data
            }, function (error) {
                // Handle
            });
        }

        vm.removeFromTable = function (personId) {
            SeatingService.removeFromTable(personId).then(function (result) {
                vm.getSeatings();
            });
        }

        vm.addToTablePopup = function (tableId) {
            var modalInstance = $uibModal.open({
                templateUrl: 'weddingApp/seating/dialog/addToTableDialog.template.html',
                controller: 'AddToTableDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    tableId: function () {
                        return tableId;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.loadData();
            }, function (error) {
                // Handle eror
                vm.loadData();
            });
        }

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
                vm.loadData();
            }, function (error) {
                // Handle eror
            });
        }

        vm.editTable = function (table) {
            var title = "Edit"
            vm.openDialog(table, title);
        }

        vm.loadData = function () {
            vm.getSeatings();
            vm.getPersonsWithoutTableCount();
        }

        vm.getPersonsCount();
        vm.loadData();
    }
})();