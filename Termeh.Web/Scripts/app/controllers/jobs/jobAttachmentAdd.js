'use strict';
(function () {
    var app = angular.module("termeh.controllers");
    var jobAttachmentAddController = function ($scope, $location, $routeParams, jobAttachmentDataService) {

        $scope.jobId = $routeParams.jobId;

        $scope.addAttachment = function (jobAttach) {
            jobAttach.jobId = $scope.jobId;
            jobAttachmentDataService.addJobAttachment(jobAttach)
                .then(function (jobAttach) {
                    $location.url('/Jobs/' + $scope.jobId);
                });
        };
    };
    jobAttachmentAddController.$inject = ['$scope', '$location', '$routeParams', 'jobAttachmentDataService'];

    app.controller("JobAttachmentAddCtrl", jobAttachmentAddController);

}());
