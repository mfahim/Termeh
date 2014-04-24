app.factory('jobSvc', ['$resource', '$q', 'serviceHelperSvc', function ($resource, $q, serviceHelper) {
    var jobServiceInstance = serviceHelper.Job;

    return {
        getTopFiveJobs: function () {
            return jobServiceInstance.query({ count: 5 });
        },
        getJobs: function () {
            return jobServiceInstance.query();
        },
        deleteJob: function (jobId) {
            return jobServiceInstance.delete({ jobId: jobId }).$promise;
        },
        addJob: function (job) {
            return jobServiceInstance.save(job).$promise;
        },
        editJob: function (job) {
            return jobServiceInstance.update(job).$promise;
        },
        getJob: function (id) {
            return jobServiceInstance.get({ jobId: id });
        }
    };
}]);