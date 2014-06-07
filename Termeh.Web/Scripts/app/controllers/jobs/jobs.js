app.controller('JobsCtrl', ['$scope', 'jobSvc', '$location', 'confirmSvc', function ($scope, jobSvc, $location, confirmSvc) {

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

    $scope.onSelect = function ($item, $model, $label) {
        $scope.selectedJob = $item;
        $scope.$model = $model;
        $scope.$label = $label;
        $location.url('/Jobs/' + $scope.selectedJob.Id);
    };

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