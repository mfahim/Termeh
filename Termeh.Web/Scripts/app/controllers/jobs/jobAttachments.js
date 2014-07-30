'use strict';
(function () {
    var app = angular.module("termeh.controllers");
    var jobAttachmentController = function ($scope, $routeParams, jobAttachmentDataService) {

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
            jobAttachmentDataService.deleteJobAttachment(jobAttachmentId)
            .then(function (data) {
                loadJobAttachments();
            });
        };
    };
    jobAttachmentController.$inject = ['$scope', '$routeParams', 'jobAttachmentDataService'];

    app.controller("JobAttachmentCtrl", jobAttachmentController);

}());
