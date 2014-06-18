'use strict';
(function () {
    var jobAttachmentController = function ($scope, $routeParams, jobAttachmentDataService, confirmSvc) {

        init();

        function init() {
            loadJobAttachments();
        }

        function loadJobAttachments() {
            jobAttachmentDataService.getAttachmentsForAJob($routeParams.jobId).$promise.then(function (data) {
                $scope.jobAttachments = data;
            });
        }

        $scope.deleteJobAttachment = function (jobAttachmentId) {
            if (confirmSvc.confirm('Are you sure you want to delete this item?')) {
                jobAttachmentDataService.deleteJobAttachment(jobAttachmentId)
                .then(function (data) {
                    loadJobAttachments();
                });
            }
        };
    };
    jobAttachmentController.$inject = ['$scope', '$routeParams', 'jobAttachmentDataService', 'confirmSvc'];

    angular.module("termeh", [])
        .controller("jobAttachmentCtrl", jobAttachmentController);

}());
