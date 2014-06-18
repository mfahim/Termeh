'use strict';
(function () {
    var jobEditController = function ($scope, $location, $routeParams, jobDataService, userSvc) {

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

                userSvc.get().$promise.then(function (data) {
                    $scope.users = data;
                });
            }
        };
        
    jobEditController.$inject = ['$scope', '$location', '$routeParams', 'jobDataService', 'userSvc'];

    angular.module("termeh", [])
        .controller("jobEditCtrl", jobEditController);

}());
