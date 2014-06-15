'use strict';
(function () {
    var userDataService = function ($resource, helperService) {
        var userApi = helperService.User;

        return {
            get: function() {
                return userApi.query();
            }
        };
    };
    userDataService.$inject = ['$resource', 'helperService'];
    angular.module("termeh.user.service", []).factory('userDataService', userDataService);
}());
