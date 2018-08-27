(function () {
    'use strict';

    angular.module("app.persons").factory("PersonService", PersonService);

    PersonService.$inject = ['$http'];

    function PersonService($http) {

        var serviceBase = "http://localhost:60472/";
        var PersonServiceFactory = {};

        var getPersonsData = function () {
            return $http.get(serviceBase + 'api/person/get', {
                skipAuthorization: true
            }).then(function (persons) {
                return persons;
            });
        }
        var addNewPerson = function (personModel) {
            return $http.post(serviceBase + 'api/person/create', personModel).then(function (newPerson) {
                return newPerson;
            })
        }
        var updatePerson = function (personModel) {
            return $http.put(serviceBase + 'api/person/update', personModel).then(function (updatedPerson) {
                return updatedPerson;
            })
        }
        var deletePerson = function (id) {
            return $http.delete(serviceBase + 'api/person/delete?id=' + id).then(function (deletedPerson) {
                return deletedPerson;
            });
        }

        PersonServiceFactory.getPersonsData = getPersonsData;
        PersonServiceFactory.addNewPerson = addNewPerson;
        PersonServiceFactory.updatePerson = updatePerson;
        PersonServiceFactory.deletePerson = deletePerson;

        return PersonServiceFactory;
    }

})()