angular.module('app.seating').controller('AddToTableDialogController', function ($uibModalInstance, PersonService, TableService, SeatingService, tableId) {

    var vm = this;
    console.log(tableId);
    vm.tableId = tableId;
    vm.persons = [];

    vm.getAllWithoutTable = function () {
        PersonService.getAllWithoutTable().then(function (result) {
            vm.persons = result.data;
        }, function (error) {
            // Handle
        });
    };

    vm.addToTable = function (personId) {
        SeatingService.addToTable(personId, vm.tableId).then(function (result) {
            vm.getAllWithoutTable();
        });
    }

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };

    vm.getAllWithoutTable();
});