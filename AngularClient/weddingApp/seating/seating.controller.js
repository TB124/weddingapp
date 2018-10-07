(function () {
    'use strict';

    angular.module('app.seating').controller('SeatingController', SeatingController);

    SeatingController.$inject = ['$scope', '$uibModal', 'SeatingService']

    function SeatingController($scope, $uibModal, SeatingService) {

        var vm = this;
        vm.seatings = [];

        vm.getSeatings = function () {
            SeatingService.getSeatingData().then(function (response) {
                vm.seatings = response.data;
            }, function (error) {
                // Handle eror
                console.log(error);
            });
        }

        vm.getSeatings();
    }
})();