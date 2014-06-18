'use strict';
(function () {
    var jobController = function ($scope, $routeParams, $location, jobDataService, userDataService, jobAttachmentDataService) {

        $scope.job = { hasActivites: false };

        $scope.addJob = function (jb) {
            jobDataService.addJob(jb)
            .then(function (data) {
                $location.url('/Jobs');
            });
        };

        init();

        function init() {

            jobDataService.getJob($routeParams.jobId).$promise.then(function (data) {
                $scope.job = data;
            });

            userDataService.get().$promise.then(function (data) {
                $scope.users = data;
            });

            jobAttachmentDataService.getAttachmentsForAJob($routeParams.jobId).$promise.then(function (data) {
                $scope.jobAttachments = data;
            });
        }
    };
    jobController.$inject = ['$scope', '$routeParams', '$location', 'jobDataService', 'userDataService', 'jobAttachmentDataService'];

    angular.module("termeh", [])
        .controller("jobCtrl", jobController);

}());
