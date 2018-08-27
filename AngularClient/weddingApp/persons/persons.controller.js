(function () {
    'use strict';

    angular.module('app.persons').controller('PersonsController', PersonsController);

    PersonsController.$inject = ['$scope', '$uibModal', 'PersonService']

    function PersonsController($scope, $uibModal, PersonService) {

        var vm = this;
        vm.persons = [];

        vm.getPersons = function () {
            PersonService.getPersonsData().then(function (response) {
                vm.persons = response.data;
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.getPersons();

        vm.openDialog = function (person, title) {
            var modalInstance = $uibModal.open({
                templateUrl: 'weddingApp/persons/dialog/personDialog.template.html',
                controller: 'PersonDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    person: function () {
                        return person;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getPersons();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.addPerson = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editPerson = function (person) {
            var title = "Edit"
            vm.openDialog(person, title);
        }

        vm.deletePerson = function (personId) {
            PersonService.deletePerson(personId).then(function (response) {
                vm.getPersons();
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }
    }
})();