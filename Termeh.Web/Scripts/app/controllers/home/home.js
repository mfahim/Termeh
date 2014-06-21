var controllerModule = angular.module('termeh.controllers');
controllerModule.controller("homeCtrl", ['$scope', function ($scope) {

    $scope.jobs = [1, 2, 34, 5];
}]);
    

//'use strict';
//(function () {
//    var homeController = function ($scope) {

//        $scope.jobs = [1, 2, 34, 5];
//        //var jobApi = helperService.Job;
        
//        init();

//        function init() {
//            //jobApi.getJobs().$promise.then(function (data) {
//            //    $scope.jobs = data;
//            //});
//        }
//    };
//    homeController.$inject = ['$scope'];

//    var module = angular.module("termeh");
//    module.controller("homeCtrl", homeController);
//}());

