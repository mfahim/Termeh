'use strict';
(function () {
    var app = angular.module("termeh.controllers");
    var resourceManagerCtrl = function ($scope, $location) {

        init();

        function init() {
            $location.url('/Home');
        }
    };
    resourceManagerCtrl.$inject = ['$scope', '$location'];

    app.controller("ResourceManagerCtrl", resourceManagerCtrl);

}());
