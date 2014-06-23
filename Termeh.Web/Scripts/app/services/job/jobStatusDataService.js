'use strict';
(function () {
    
    var app = angular.module("termeh.services");
    var jobStatusDataService = function ($resource, helperService) {
        var jobStatusApi = helperService.JobStatus;

        return {
            get: function () {
                return jobStatusApi.query();
                }
            };
    };

    jobStatusDataService.$inject = ['$resource', 'helperService'];
    app.factory('jobStatusDataService', jobStatusDataService);
    
}());