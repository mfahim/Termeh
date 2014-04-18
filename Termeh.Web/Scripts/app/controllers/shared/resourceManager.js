app.controller('ResourceMngrCtrl', ['$scope', '$location', '$window', 'resourceMngrSvc',
    function ($scope, $location) {

    init();
    function init() {
        $location.url('/Home');
    }
}]);