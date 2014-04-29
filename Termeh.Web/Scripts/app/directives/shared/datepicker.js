app.directive('cstDatepicker', function () {
    return {
        restrict: "A",
        require: 'ngModel',
        replace: true,
        link: function (scope, element, attrs, ngModelCtrl) {
            var dPicker = element.datepicker({
                maxDate:100,
                onSelect: function (d) {
                    ngModelCtrl.$setViewValue(d);
                    scope.$apply();
                    //ngModelCtrl.$setValidity('invalid', false);
                }
            });
            element.on('keypress', function (e) {
                return false;
            });
        }

    };
});