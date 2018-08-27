angular.module('app.persons').controller('PersonDialogController', function ($uibModalInstance, PersonService, person, title, TableService, PersonGroupService) {
    var vm = this;
    vm.tables = [];
    vm.personGroups = [];

    vm.title = title;
    vm.person = person;

    vm.getPersonGroups = function () {
        PersonGroupService.getPersonGroupsData().then(function (response) {
            vm.personGroups = response.data;
        }, function (error) {
            // Handle eror
            console.log(error);
        });
    }

    vm.getTables = function () {
        TableService.getTablesData().then(function (response) {
            vm.tables = response.data;
        }, function (error) {
            // Handle eror
            console.log(error);
        });
    }

    vm.getPersonGroups();
    vm.getTables();

    vm.save = function () {
        if (vm.person.id == undefined) {
            PersonService.addNewPerson(vm.person).then(function (response) {
                $uibModalInstance.close({ response: response });
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
        else {
            PersonService.updatePerson(vm.person).then(function (response) {
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