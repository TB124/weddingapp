angular.module('app.tables').controller('TableDialogController', function ($uibModalInstance, TableService, table, title) {
    var vm = this;

    vm.title = title;
    vm.table = table;

    vm.save = function () {
        if (vm.table.id == undefined) {
            TableService.addNewTable(vm.table).then(function (response) {
                $uibModalInstance.close({ response: response });
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
        else {
            TableService.updateTable(vm.table).then(function (response) {
                $uibModalInstance.close({response: response});
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
    
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});