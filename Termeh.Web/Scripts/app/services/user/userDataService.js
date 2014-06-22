'use strict';
(function () {
    var app = angular.module("termeh.services");
    var userDataService = function ($resource, helperService) {
        var userApi = helperService.User;

        return {
            get: function() {
                return userApi.query();
            }
        };
    };
    userDataService.$inject = ['$resource', 'helperService'];
    app.factory('userDataService', userDataService);
}());
