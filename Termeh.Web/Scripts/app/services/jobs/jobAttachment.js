app.factory('jobAttachmentSvc', ['$resource', '$q', 'serviceHelperSvc', function ($resource, $q, serviceHelper) {
    var jobAttachService = serviceHelper.JobAttachment;

    return {
        getAttachmentsForAJob: function (jobId) {
            return jobAttachService.query({ jobId: jobId });
        },
        deleteJobAttachment: function (attachmentId) {
            return jobAttachService.delete({ attachmentId: attachmentId }).$promise;
        },
        addJobAttachment: function (jobAttachment) {
            return jobAttachService.save({ jobAttachmentId: jobAttachment.Id }, jobAttachment).$promise;
        },
        getJobAttachment: function (attachmentId) {
            return jobAttachService.get({ jobAttachmentId: attachmentId });
        }
    };
}]);
