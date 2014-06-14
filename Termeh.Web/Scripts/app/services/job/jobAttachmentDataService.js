'use strict';
(function() {
    var jobAttachmentDataService = function ($resource, $q, helperService) {
        var jobAttachService = helperService.JobAttachment;

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
              
    jobAttachmentDataService.$inject = ['$resource', '$q', 'helperService'];
    angular.module("termeh.job.service", []).factory('jobAttachmentDataService', jobAttachmentDataService);
}());
