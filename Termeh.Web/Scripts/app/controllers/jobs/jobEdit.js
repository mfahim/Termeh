app.controller('JobEditCtrl', ['$scope', '$location', '$routeParams', 'jobSvc',
    function ($scope, $location, $routeParams, jobSvc) {

        init();

        $scope.editJob = function (resource) {
            jobSvc.editJob(resource).then(function (data) {
                $location.url('/Jobs');
            });
        };

        function priorityValues() {
            var priorities = [];
            for (var i = 1; i <= 10; i++) {
                priorities.push({ priority: i });
            }

            return priorities;
        }

        function init() {
            jobSvc.createJobEditFormModel($routeParams.jobId)
         .then(function (data) {
             $scope.locations = data[1];
             $scope.job = data[0];

             //hack for issue with select2 hard coded values pre-selection.
             $scope.priorities = priorityValues();
         });
        }

    }]);