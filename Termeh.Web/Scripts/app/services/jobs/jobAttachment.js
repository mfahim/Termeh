(function () {
    var jobAttachmentSvc = function ($resource, $q, serviceHelper) {
    var jobAttachService = serviceHelper.JobAttachment;

    return {
        getAttachmentsForAJob: function(jobId) {
            return jobAttachService.query({ jobId: jobId });
        },
        deleteJobAttachment: function(attachmentId) {
            return jobAttachService.delete({ attachmentId: attachmentId }).$promise;
        },
        addJobAttachment: function(jobAttachment) {
            return jobAttachService.save({ jobAttachmentId: jobAttachment.Id }, jobAttachment).$promise;
        },
        getJobAttachment: function(attachmentId) {
            return jobAttachService.get({ jobAttachmentId: attachmentId });
        }
    };
};

jobAttachmentSvc.$inject = ['$resource', '$q', 'serviceHelperSvc'];
app.factory('jobAttachmentSvc', ['$resource', '$q', 'serviceHelperSvc'], jobAttachmentSvc);
}());