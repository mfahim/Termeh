'use strict';
(function () {

    var app = angular.module("termeh.services");
    var helperService = function ($http, $resource) {
        var baseUrl = config.apiurl;
        var buildUrl = function(resourceUrl) {
            if (resourceUrl.lastIndexOf('/') !== resourceUrl.length - 1) {
                resourceUrl += "/";
            }

            return baseUrl + resourceUrl;
        };

        return {
            Job: $resource(buildUrl('api/Job/:jobId'),
                { jobId: '@Id' },
                { 'update': { method: 'PUT' } }),

            JobAttachment: $resource(buildUrl('api/JobAttachment/:jobAttachmentId'),
                { jobAttachmentId: '@Id' },
                { 'update': { method: 'PUT' } }),

            JobStatus: $resource(buildUrl('api/JobStatus/')),

            User: $resource(buildUrl('api/User/')),
        };
    };

    helperService.$inject = ['$http', '$resource'];
    app.factory('helperService', helperService);

}());