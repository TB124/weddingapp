(function () {
    'use strict';

    angular.module('app.movies').controller('MoviesController', MoviesController);

    MoviesController.$inject = ['$scope', '$uibModal', 'weddingAppService']

    function MoviesController($scope, $uibModal, weddingAppService) {

        var vm = this;
        vm.movies = [];

        vm.getMovies = function () {
            weddingAppService.getMoviesData().then(function (response) {
                vm.movies = response.data;
            });
        }

        vm.getMovies();

        
        vm.openDialog = function (movie, title) {

            var modalInstance = $uibModal.open({
                templateUrl: 'weddingApp/movies/dialog/movieDialog.template.html',
                controller: 'MovieDialogController',
                controllerAs: 'vm',
                size: 'lg',
                resolve: {
                    movie: function () {
                        return movie;
                    },
                    title: function () {
                        return title;
                    }
                }
            });
            modalInstance.result.then(function (response) {
                vm.getMovies();
            });
        }


        vm.addMovie = function () {
            var title = "Add new"
            vm.openDialog(undefined, title)
        }

        vm.editMovie = function (movie) {
            var title = "Edit"
            vm.openDialog(movie, title);
        }

        vm.deleteMovie = function (movieId) {
            weddingAppService.deleteMovie(movieId).then(function (response) {
                vm.getMovies();
            });

        }
    }
})();