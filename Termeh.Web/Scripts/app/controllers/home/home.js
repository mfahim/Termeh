'use strict';
(function () {
    var homeController = function($scope, jobSvc) {

        init();

        function init() {
        }
    };
    homeController.$inject = ['$scope', 'jobSvc'];

    angular.module("termeh.ctrl.homeCtrl", [])
        .controller("homeCtrl", homeController);
    
}());
