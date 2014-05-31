window.app = angular.module('resourceManagerApp', ['ui.select2', 'ui.bootstrap', 'ngRoute', 'ngResource', 'ngAnimate']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', 
    function ($routeProvider, $locationProvider, $httpProvider, $provide) {

    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $httpProvider.defaults.useXDomain = true;
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/Login', { templateUrl: '/Scripts/app/views/login/Login.html' })
        .when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        .when('/JobAttachments/Add/:jobId', { templateUrl: '/Scripts/app/views/jobAttachments/add.html', controller: 'JobAttachmentAddCtrl' })
        .when('/Jobs', { templateUrl: '/Scripts/app/views/jobs/List.html', controller: 'JobsCtrl' })
        .when('/Jobs/Add', { templateUrl: '/Scripts/app/views/jobs/Add.html', controller: 'JobCtrl' })
        .when('/Jobs/Edit/:jobId', { templateUrl: '/Scripts/app/views/jobs/Edit.html', controller: 'JobEditCtrl', disableCache: true })
        .when('/Jobs/:jobId', { templateUrl: '/Scripts/app/views/jobs/Details.html', controller: 'JobCtrl', disableCache: true })
        .when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl', disableCache: true })
        .when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html'})
        .otherwise({ redirectTo: '/Home', disableCache: true });

    }]);

app.run(function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
});


