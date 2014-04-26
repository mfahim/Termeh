app.controller('JobEditCtrl', ['$scope', '$location', '$routeParams', 'jobSvc',
    function ($scope, $location, $routeParams, jobSvc) {

        init();

        $scope.editJob = function (resource) {
            jobSvc.editJob(resource).then(function (data) {
                $location.url('/Jobs');
            });
        };

        function init() {
            jobSvc.createJobEditFormModel($routeParams.jobId)
            .then(function (data)
            {
                $scope.job = data[0];
            });
        }

}]);