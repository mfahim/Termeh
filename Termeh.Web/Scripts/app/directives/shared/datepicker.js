﻿'use strict';
(function () {
    var app = angular.module("termeh");
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
                }
            });
            element.on('keypress', function (e) {
                return false;
            });
        }

    };
    });
}());