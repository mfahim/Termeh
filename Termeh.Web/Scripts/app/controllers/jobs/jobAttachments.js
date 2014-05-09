app.controller('JobAttachmentCtrl', ['$scope', '$routeParams', 'jobAttachmentSvc',
    function ($scope, $routeParams, jobAttachmentSvc) {
        init();

        function init() {

            jobAttachmentSvc.getAttachmentsForAJob($routeParams.jobId).$promise.then(function (data) {
                $scope.jobAttachments = data;
            });
        }
    }]);