
app = angular.module("termeh", ['ui.select2', 'ui.bootstrap', 'ngRoute', 'ngResource', 'ngAnimate',
    'termeh.services.jobAttachment', 'termeh.services.job', 'termeh.services.jobStatus',
    'termeh.ctrl.homeCtrl', 'termeh.ctrl.jobsCtrl', 'termeh.ctrl.jobCtrl',
    'termeh.ctrl.jobAttachmentAddCtrl', 'termeh.ctrl.jobAttachmentCtrl',
    'termeh.ctrl.jobEditCtrl', 'termeh.ctrl.resourceManagerCtrl'
]);

app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', 
    function ($routeProvider, $locationProvider, $httpProvider) {

    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $httpProvider.defaults.useXDomain = true;
    $locationProvider.html5Mode(true);
    $routeProvider
        .when('/Login', { templateUrl: '/Scripts/app/views/login/Login.html' })
        .when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        .when('/JobAttachments/Add/:jobId', { templateUrl: '/Scripts/app/views/jobAttachments/add.html', controller: 'jobAttachmentAddCtrl' })
        .when('/Jobs', { templateUrl: '/Scripts/app/views/jobs/List.html', controller: 'jobsCtrl' })
        .when('/Jobs/Add', { templateUrl: '/Scripts/app/views/jobs/Add.html', controller: 'jobCtrl' })
        .when('/Jobs/Edit/:jobId', { templateUrl: '/Scripts/app/views/jobs/Edit.html', controller: 'jobEditCtrl', disableCache: true })
        .when('/Jobs/:jobId', { templateUrl: '/Scripts/app/views/jobs/Details.html', controller: 'jobCtrl', disableCache: true })
        .when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'HomeCtrl', disableCache: true })
        .when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html'})
        .otherwise({ redirectTo: '/Home', disableCache: true });

    }]);

app.run(['$rootScope', '$templateCache', function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
}]);
