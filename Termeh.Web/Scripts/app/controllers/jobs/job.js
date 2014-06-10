'use strict';
(function () {
    var jobController = function ($scope, $routeParams, $location, jobSvc, userSvc, jobAttachmentSvc) {

        $scope.job = { hasActivites: false };

        $scope.addJob = function (jb) {
            jobSvc.addJob(jb)
            .then(function (data) {
                $location.url('/Jobs');
            });
        };

        init();

        function init() {

            jobSvc.getJob($routeParams.jobId).$promise.then(function (data) {
                $scope.job = data;
            });

            userSvc.get().$promise.then(function (data) {
                $scope.users = data;
            });

            jobAttachmentSvc.getAttachmentsForAJob($routeParams.jobId).$promise.then(function (data) {
                $scope.jobAttachments = data;
            });
        }
    };
    jobController.$inject = ['$scope', '$routeParams', '$location', 'jobSvc', 'userSvc', 'jobAttachmentSvc'];

    angular.module("termeh.ctrl.jobCtrl", [])
        .controller("jobCtrl", jobController);

}());
