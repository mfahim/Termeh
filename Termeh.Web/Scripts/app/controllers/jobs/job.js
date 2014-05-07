app.controller('JobCtrl', ['$scope', '$routeParams', '$location', 'jobSvc', 'userSvc', 'jobAttachmentSvc',
    function ($scope, $routeParams, $location, jobSvc, userSvc, jobAttachmentSvc) {
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
}]);