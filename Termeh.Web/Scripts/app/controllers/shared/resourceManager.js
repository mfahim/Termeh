'use strict';
(function () {
    var resourceManagerController = function ($scope, $location) {

        init();

        function init() {
            $location.url('/Home');
        }
    };
    resourceManagerController.$inject = ['$scope', '$location', 'resourceMngrSvc'];

    angular.module("termeh.ctrl.resourceManagerCtrl", [])
        .controller("resourceManagerCtrl", resourceManagerController);

}());
