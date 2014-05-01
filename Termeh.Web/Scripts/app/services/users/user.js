app.factory('userSvc', ['$resource', 'serviceHelperSvc', function ($resource, serviceHelper) {
    var User = serviceHelper.User;

    return {
        get: function () {
            return User.query();
        }
    };
}]);