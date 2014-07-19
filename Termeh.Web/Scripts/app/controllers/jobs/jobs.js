'use strict';
(function () {
    var app = angular.module("termeh.controllers");
    var jobsCtrl = function ($scope, jobDataService, $location, confirmSvc) {

        $scope.jobs = [];
        $scope.deleteJob = function (jobId) {
            jobDataService.deleteJob(jobId)
            .then(function (data) {
                loadJobs();
            });
        };

        init();

        $scope.whenEnterPressed = function () {
            $location.url('/Jobs/' + $scope.selectedJob.Id);
        };

        $scope.onSelect = function ($item, $model, $label) {
            $scope.selectedJob = $item;
            $scope.$model = $model;
            $scope.$label = $label;

            $scope.whenEnterPressed();
        };

        function init() {
            $scope.loading = true;
            loadJobs();
        }

        function loadJobs() {
            jobDataService.getJobs().$promise.then(function (data) {
                $scope.jobs = data;
                $scope.loading = false;
            });
        }
    };
    jobsCtrl.$inject = ['$scope', 'jobDataService', '$location', 'confirmSvc'];

    app.controller("JobsCtrl", jobsCtrl);
}());
