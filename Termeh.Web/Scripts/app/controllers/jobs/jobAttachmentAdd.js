app.controller('JobAttachmentAddCtrl', ['$scope', '$location', '$routeParams', 'jobAttachmentSvc', function ($scope, $location, $routeParams, jobAttachmentSvc) {

    $scope.jobId = $routeParams.jobId;
    
    $scope.addAttachment = function (jobAttach) {
        jobAttach.jobId = $scope.jobId;
        jobAttachmentSvc.addJobAttachment(jobAttach)
            .then(function (jobAttach) {
                $location.url('/Jobs/' + $scope.jobId);
            });
    };
}]);