'use strict';
(function () {
    var app = angular.module("termeh.services");
    var jobDataService = function ($resource, $q, helperService) {
        var jobApi = helperService.Job;

        return {
            getTopFiveJobs: function() {
                return jobApi.query({ count: 5 });
            },
            getJobs: function () {
                return jobApi.query();
            },
            deleteJob: function(jobId) {
                return jobApi.delete({ jobId: jobId }).$promise;
            },
            addJob: function(job) {
                return jobApi.save(job).$promise;
            },
            editJob: function(job) {
                return jobApi.update(job).$promise;
            },
            getJob: function(id) {
                return jobApi.get({ jobId: id });
            },
            createJobEditFormModel: function(jobId) {
                var singleJob = $q.all([this.getJob(jobId).$promise]);
                singleJob.then(function(data) {
                    return data;
                });
                return singleJob;
            }
        };

    };
    
    jobDataService.$inject = ['$resource', '$q', 'helperService'];
    app.factory('jobDataService', jobDataService);
}());