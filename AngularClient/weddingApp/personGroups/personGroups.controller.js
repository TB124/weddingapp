(function () {
    'use strict';

    angular.module('app.personGroups').controller('PersonGroupsController', PersonGroupsController);

    PersonGroupsController.$inject = ['$scope', '$uibModal', 'PersonGroupService', 'TableService']

    function PersonGroupsController($scope, $uibModal, PersonGroupService, TableService) {

        var vm = this;
        vm.personGroups = [];

        vm.getPersonGroups = function () {
            PersonGroupService.getPersonGroupsData().then(function (response) {
                vm.personGroups = response.data;
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.getPersonGroups();

        vm.openDialog = function (personGroup, title) {
            var modalInstance = $uibModal.open({
                templateUrl: 'weddingApp/personGroups/dialog/personGroupDialog.template.html',
                controller: 'PersonGroupDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    personGroup: function () {
                        return personGroup;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getPersonGroups();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.addPersonGroup = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editPersonGroup = function (personGroup) {
            var title = "Edit"
            vm.openDialog(personGroup, title);
        }

        vm.deletePersonGroup = function (personGroupId) {
            PersonGroupService.deletePersonGroup(personGroupId).then(function (response) {
                vm.getPersonGroups();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
    }
})();