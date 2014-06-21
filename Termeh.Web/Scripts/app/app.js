
//angular.module("termeh.job.service", []);
//angular.module("termeh.user.service", []);
//var ctrls = angular.module("termeh.controllers", []);
var app = angular.module("termeh", ['ui.select2', 'ui.bootstrap', 'ngRoute', 'ngResource', 'ngAnimate',
    'termeh.controllers'
    //'termeh.job.service', 'termeh.user.service'
    //'termeh.ctrl.jobsCtrl', 'termeh.ctrl.jobCtrl',
    //'termeh.ctrl.jobAttachmentAddCtrl', 'termeh.ctrl.jobAttachmentCtrl',
    //'termeh.ctrl.jobEditCtrl'
]);


app.config(['$routeProvider', '$locationProvider', '$httpProvider', '$provide', 
    function ($routeProvider, $locationProvider, $httpProvider) {

    $httpProvider.defaults.useXDomain = true;
    delete $httpProvider.defaults.headers.common['X-Requested-With'];
    $locationProvider.html5Mode(true);
    //$routeProvider
        //.when('/Login', { templateUrl: '/Scripts/app/views/login/Login.html' })
        //.when('/About', { templateUrl: '/Scripts/app/views/about/About.html' })
        //.when('/JobAttachments/Add/:jobId', { templateUrl: '/Scripts/app/views/jobAttachments/add.html', controller: 'jobAttachmentAddCtrl' })
        //.when('/Jobs', { templateUrl: '/Scripts/app/views/jobs/List.html', controller: 'jobsCtrl' })
        //.when('/Jobs/Add', { templateUrl: '/Scripts/app/views/jobs/Add.html', controller: 'jobCtrl' })
        //.when('/Jobs/Edit/:jobId', { templateUrl: '/Scripts/app/views/jobs/Edit.html', controller: 'jobEditCtrl', disableCache: true })
        //.when('/Jobs/:jobId', { templateUrl: '/Scripts/app/views/jobs/Details.html', controller: 'jobCtrl', disableCache: true })
        //.when('/Home', { templateUrl: '/Scripts/app/views/home/Home.html', controller: 'homeCtrl', disableCache: true })
        //.when('/Error', { templateUrl: '/Scripts/app/views/shared/Error.html'})
        //.otherwise({ redirectTo: '/Home', disableCache: true });
    }]);

app.run(['$rootScope', '$templateCache', function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
}]);
