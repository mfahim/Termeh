'use strict';
(function () {
    var app = angular.module("termeh.controllers");
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

    app.controller("JobAttachmentCtrl", jobAttachmentController);

}());
