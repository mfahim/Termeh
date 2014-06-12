(function () {
    var jobSvc = function($resource, $q, serviceHelper) {
    var jobServiceInstance = serviceHelper.Job;

    return {
        getTopFiveJobs: function() {
            return jobServiceInstance.query({ count: 5 });
        },
        getJobs: function() {
            return jobServiceInstance.query();
        },
        deleteJob: function(jobId) {
            return jobServiceInstance.delete({ jobId: jobId }).$promise;
        },
        addJob: function(job) {
            return jobServiceInstance.save(job).$promise;
        },
        editJob: function(job) {
            return jobServiceInstance.update(job).$promise;
        },
        getJob: function(id) {
            return jobServiceInstance.get({ jobId: id });
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
    
    jobSvc.$inject = ['$resource', '$q', 'serviceHelperSvc'];
    app.factory('jobSvc', jobSvc);
}());