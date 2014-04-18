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
        addJob: function (resource) {
            return jobServiceInstance.save(resource).$promise;
        },
        editJob: function (resource) {
            return jobServiceInstance.update(resource).$promise;
        },
        getJob: function (id) {
            return jobServiceInstance.get({ jobId: id });
        },
        createJobAddFormModel: function () {
            return jobServiceInstance.getLocations();
        },
        createJobEditFormModel: function (jobId) {
            var sample = $q.all([this.getJob(jobId).$promise]);
            sample.then(function (data) {
                return data;
            });
            return sample;
        }
    };
}]);