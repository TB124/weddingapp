angular.module('app.movies').controller('MovieDialogController', function ($uibModalInstance, weddingAppService, movie, title) {
    var vm = this;

    vm.title = title;
    vm.movie = movie;

    vm.save = function () {
        if (vm.movie.id == undefined) {
            weddingAppService.addNewMovie(vm.movie).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
        else {
            weddingAppService.updateMovie(vm.movie).then(function (response) {
                $uibModalInstance.close({response: response});
            });
        }
    
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});