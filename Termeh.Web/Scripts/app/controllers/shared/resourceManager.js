'use strict';
(function () {
    var resourceManagerCtrl = function ($scope, $location) {

        init();

        function init() {
            $location.url('/Home');
        }
    };
    resourceManagerCtrl.$inject = ['$scope', '$location'];

    angular.module("termeh.ctrl", [])
        .controller("resourceManagerCtrl", resourceManagerCtrl);

}());
