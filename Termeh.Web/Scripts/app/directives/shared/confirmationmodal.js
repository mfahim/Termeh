﻿'use strict';
(function () {
    var app = angular.module("termeh");
    app.directive('confirmationModal', function () {
        return {
            restrict: 'E',
            scope: {
                approve: '&onApprove',
                deny: '&onDeny',
                closable: '=closable',
                modalTitle: '=modalTitle'
            },
            template: '<a href="javascript:;"><i class="trash icon"></i></a><div class="ui basic modal" id="modal">' +
                        '<div class="header">{{modalTitle}}</div><div class="content"><div class="left"> {{modalTitle}} Content can appear on left</div><div class="right">' +
                        'Content can appear on right</div></div><div class="actions"><div class="two fluid ui buttons"><div ng-click="closeModal();deny();" class="ui negative labeled icon button">No</div>' +
                        '<div class="ui positive labeled icon button button" ng-click="approve();">Yes</div></div></div></div>',
            link: function (scope, element, attrs, ngModelCtrl) {

                scope.closeModal = function () {
                    alert('from link scope');
                };

                element.on('click', function (e) {
                    $('#modal').modal({ 'closable': scope.closable }).modal('show');
                });
            }
        };

        function closeModal() {
            $('#modal').modal('hide');
        }
    });
}());