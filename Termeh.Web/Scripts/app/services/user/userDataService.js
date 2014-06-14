'use strict';
(function () {
    var userDataService = function($resource, serviceHelper) {
        var userApi = serviceHelper.User;

        return {
            get: function() {
                return userApi.query();
            }
        };
    };
    userDataService.$inject = ['$resource', 'serviceHelperSvc'];
    angular.module("termeh.user.service", []).factory('userDataService', userDataService);
}());
