﻿(function () {
    
    var jobStatusSvc = function ($resource, serviceHelper) {
    var JobStatus = serviceHelper.JobStatus;

    return {
        get: function () {
            return JobStatus.query();
        }
    };
 };

jobStatusSvc.$inject = ['$resource', 'serviceHelperSvc'];
app.factory('jobStatusSvc', jobStatusSvc);
    
}());