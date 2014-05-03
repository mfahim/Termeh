app.controller('JobsCtrl', ['$scope', 'jobSvc', 'confirmSvc', function ($scope, jobSvc, confirmSvc) {

    $scope.jobs = [];

    $scope.deleteJob = function (jobId) {
        if (confirmSvc.confirm('Are you sure you want to delete this item?')) {
            jobSvc.deleteJob(jobId)
            .then(function (data) {
                loadJobs();
            });
        }
    };

    init();

    function init() {
        $scope.loading = true;
        loadJobs();
    }

    function loadJobs() {
        jobSvc.getJobs().$promise.then(function (data) {
            $scope.jobs = data;
            $scope.loading = false;
        });
    }
}]);