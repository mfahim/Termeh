'use strict';
(function () {
    var jobAttachmentAddController = function ($scope, $location, $routeParams, jobAttachmentSvc) {

        $scope.jobId = $routeParams.jobId;

        $scope.addAttachment = function (jobAttach) {
            jobAttach.jobId = $scope.jobId;
            jobAttachmentSvc.addJobAttachment(jobAttach)
                .then(function (jobAttach) {
                    $location.url('/Jobs/' + $scope.jobId);
                });
        };
    };
    jobAttachmentAddController.$inject = ['$scope', '$location', '$routeParams', 'jobAttachmentSvc'];

    angular.module("termeh.ctrl.jobAttachmentAddCtrl", [])
        .controller("jobAttachmentAddCtrl", jobAttachmentAddController);

}());
