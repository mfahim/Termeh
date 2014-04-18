app.controller('JobCtrl', ['$scope', '$routeParams', '$location', 'jobSvc',
    function ($scope, $routeParams, $location, jobSvc) {
    $scope.job = { hasActivites: false };
    $scope.addJob = function (jb) {
        jobSvc.addJob(jb)
        .then(function (data) {
            $location.url('/Jobs');
        });
    };

    init();

    function init() {
        
        if ($routeParams.jobId > 0) {
            jobSvc.getJob($routeParams.jobId).$promise.then(function (data) {
                $scope.job = data;
            });
        }
        else {
            //$scope.locations = jobSvc.createJobAddFormModel();
        }
    }
}]);