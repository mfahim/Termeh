app.factory('jobAttachmentSvc', ['$resource', '$q', 'serviceHelperSvc', function ($resource, $q, serviceHelper) {
    var jobAttachService = serviceHelper.JobAttachment;

    return {
        getAttachmentsForAJob: function (jobId) {
            return jobAttachService.query({ jobId: jobId });
        },
        deleteJobAttachment: function (jobId) {
            return jobAttachService.delete({ jobId: jobId }).$promise;
        },
        addJobAttachment: function (jobAttachment) {
            return jobAttachService.save(jobAttachment).$promise;
        },
        getJobAttachment: function (attachmentId) {
            return jobAttachService.get({ jobAttachmentId: attachmentId });
        }
    };
}]);
