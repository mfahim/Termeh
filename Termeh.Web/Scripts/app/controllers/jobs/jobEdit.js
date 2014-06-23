'use strict';
(function () {
    var app = angular.module("termeh.controllers");
    var jobEditController = function ($scope, $location, $routeParams, jobDataService, userDataService) {

            init();

            $scope.editJob = function (job) {
                jobDataService.editJob(job).then(function (data) {
                    $location.url('/Jobs');
                });
            };

            function init() {
                jobDataService.createJobEditFormModel($routeParams.jobId)
                .then(function (data)
                {
                    $scope.job = data[0];
                });

                userDataService.get().$promise.then(function (data) {
                    $scope.users = data;
                });
            }
        };
        
    jobEditController.$inject = ['$scope', '$location', '$routeParams', 'jobDataService', 'userDataService'];

    app.controller("JobEditCtrl", jobEditController);

}());
