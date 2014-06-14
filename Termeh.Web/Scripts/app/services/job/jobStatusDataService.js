'use strict';
(function () {
    
    var jobStatusDataService = function ($resource, helperService) {
        var jobStatusApi = helperService.JobStatus;

    return {
        get: function () {
            return jobStatusApi.query();
            }
        };
    };

    jobStatusDataService.$inject = ['$resource', 'helperService'];
    angular.module("termeh.job.service", []).factory('jobStatusDataService', jobStatusDataService);
    
}());