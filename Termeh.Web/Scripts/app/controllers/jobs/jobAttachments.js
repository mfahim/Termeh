'use strict';
(function () {
    var jobAttachmentController = function ($scope, $routeParams, jobAttachmentSvc, confirmSvc) {

        init();

        function init() {
            loadJobAttachments();
        }

        function loadJobAttachments() {
            jobAttachmentSvc.getAttachmentsForAJob($routeParams.jobId).$promise.then(function (data) {
                $scope.jobAttachments = data;
            });
        }

        $scope.deleteJobAttachment = function (jobAttachmentId) {
            if (confirmSvc.confirm('Are you sure you want to delete this item?')) {
                jobAttachmentSvc.deleteJobAttachment(jobAttachmentId)
                .then(function (data) {
                    loadJobAttachments();
                });
            }
        };
    };
    jobAttachmentController.$inject = ['$scope', '$routeParams', 'jobAttachmentSvc', 'confirmSvc'];

    angular.module("termeh.ctrl.jobAttachmentCtrl", [])
        .controller("jobAttachmentCtrl", jobAttachmentController);

}());
