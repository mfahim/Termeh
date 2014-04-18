app.factory('serviceHelperSvc', ['$http', '$resource', function ($http, $resource) {
    var baseUrl = config.apiurl;
    //var baseUrl = '';
    var buildUrl = function (resourceUrl) {
        if (resourceUrl.lastIndexOf('/') !== resourceUrl.length - 1) {
            resourceUrl += "/";
        }

        return baseUrl + resourceUrl;
    };
    var addRequestHeader = function (key, value) {

    };

    return {
        Job: $resource(buildUrl('api/Job/:jobId'),
            { jobId: '@Id' },
            { 'update': { method: 'PUT' } }),
        
        setAuthroizationHeader: function (value) {
            $http.defaults.headers.common.Authorization = "Bearer " + value;
        }
    };
}]);