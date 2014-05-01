app.factory('jobStatusSvc', ['$resource', 'serviceHelperSvc', function ($resource, serviceHelper) {
    var JobStatus = serviceHelper.JobStatus;

    return {
        get: function () {
            return JobStatus.query();
        }
    };
}]);