(function () {
    'use strict';

    angular.module("app.personGroups").factory("PersonGroupService", PersonGroupService);

    PersonGroupService.$inject = ['$http'];

    function PersonGroupService($http) {

        var serviceBase = "http://localhost:60472/";
        var PersonGroupServiceFactory = {};

        var getPersonGroupsData = function () {
            return $http.get(serviceBase + 'api/personGroup/get', {
                skipAuthorization: true
            }).then(function (personGroups) {
                return personGroups;
            });
        }
        var addNewPersonGroup = function (personGroupModel) {
            return $http.post(serviceBase + 'api/personGroup/create', personGroupModel).then(function (newPersonGroup) {
                return newPersonGroup;
            })
        }
        var updatePersonGroup = function (personGroupModel) {
            return $http.put(serviceBase + 'api/personGroup/update', personGroupModel).then(function (updatedPersonGroup) {
                return updatedPersonGroup;
            })
        }
        var deletePersonGroup = function (id) {
            return $http.delete(serviceBase + 'api/personGroup/delete?id=' + id).then(function (deletedPersonGroup) {
                return deletedPersonGroup;
            });
        }

        PersonGroupServiceFactory.getPersonGroupsData = getPersonGroupsData;
        PersonGroupServiceFactory.addNewPersonGroup = addNewPersonGroup;
        PersonGroupServiceFactory.updatePersonGroup = updatePersonGroup;
        PersonGroupServiceFactory.deletePersonGroup = deletePersonGroup;

        return PersonGroupServiceFactory;
    }

})()