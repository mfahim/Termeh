app.directive('jobAttachmentList', function () {
    return {
        restrict: 'E',
        templateUrl: '/Scripts/app/views/jobs/jobAttachments.html',
        scope: {
            attachments: "=attachments"
        }
    };

});