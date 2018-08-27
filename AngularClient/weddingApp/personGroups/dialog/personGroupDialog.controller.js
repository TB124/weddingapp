angular.module('app.personGroups').controller('PersonGroupDialogController', function ($uibModalInstance, PersonGroupService, personGroup, title) {
    var vm = this;

    vm.title = title;
    vm.personGroup = personGroup;

    vm.save = function () {
        if (vm.personGroup.id == undefined) {
            PersonGroupService.addNewPersonGroup(vm.personGroup).then(function (response) {
                $uibModalInstance.close({ response: response });
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
        else {
            PersonGroupService.updatePersonGroup(vm.personGroup).then(function (response) {
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