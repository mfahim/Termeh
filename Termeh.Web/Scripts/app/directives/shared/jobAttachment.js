'use strict';
(function() {
    var app = angular.module("termeh");

    app.directive('jobAttachmentList', function() {
        return {
            restrict: 'E',
            templateUrl: '/Scripts/app/views/jobs/jobAttachments.html',
            scope: {
                attachments: "=attachments"
            }
        };

    });
}());