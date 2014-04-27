app.controller('JobEditCtrl', ['$scope', '$location', '$routeParams', 'jobSvc', 'userSvc',
    function ($scope, $location, $routeParams, jobSvc, userSvc) {

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

            userSvc.get().$promise.then(function (data) {
                $scope.users = data;
            });
        }

}]);