'use strict';
(function () {
    var app = angular.module("termeh.controllers");

    var homeController = function ($scope) {

        init();

        function init() {
            $scope.greeting = 'salam!';
        }
    };
    homeController.$inject = ['$scope'];

    app.controller("HomeCtrl", homeController);

}());
    