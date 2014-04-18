window.app = angular.module('resourceManagerApp', ['ui.select2', 'ngRoute', 'ngResource', 'ngAnimate']);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', 
    function ($routeProvider, $locationProvider, $httpProvider, $provide) {

    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $httpProvider.defaults.useXDomain = true;
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/Login', { templateUrl: '/Scripts/app/views/login/Login.html' })
        .when('/Locations', { templateUrl: '/Scripts/app/views/locations/Locations.html', controller: 'LocationsCtrl' })
        .when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        .when('/Locations/Add', { templateUrl: '/Scripts/app/views/locations/Add.html', controller: 'LocationCtrl' })
        .when('/Locations/Edit/:locationId', { templateUrl: '/Scripts/app/views/locations/Edit.html', controller: 'LocationCtrl' })
        .when('/Jobs', { templateUrl: '/Scripts/app/views/jobs/List.html', controller: 'JobsCtrl' })
        .when('/Jobs/Add', { templateUrl: '/Scripts/app/views/jobs/Add.html', controller: 'JobCtrl' })
        .when('/Jobs/Edit/:jobId', { templateUrl: '/Scripts/app/views/jobs/Edit.html', controller: 'JobEditCtrl', disableCache: true })
        .when('/Jobs/:jobId', { templateUrl: '/Scripts/app/views/jobs/Details.html', controller: 'JobCtrl', disableCache: true })
        .when('/Activities/Add', { templateUrl: '/Scripts/app/views/activities/Add.html', controller: 'ActivityAddCtrl' })
        .when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl', disableCache: true })
        .when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html'})
        .otherwise({ redirectTo: '/Home', disableCache: true });

    }]);

app.run(function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
});


