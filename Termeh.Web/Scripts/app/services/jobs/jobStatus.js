'use strict';
(function () {
    
    var jobStatusSvc = function ($resource, serviceHelper) {
    var JobStatus = serviceHelper.JobStatus;

    return {
        get: function () {
            return JobStatus.query();
        }
    };
 };

jobStatusSvc.$inject = ['$resource', 'serviceHelperSvc'];
angular.module("termeh.services.jobStatus", []).factory('jobStatusSvc', jobStatusSvc);
    
}());