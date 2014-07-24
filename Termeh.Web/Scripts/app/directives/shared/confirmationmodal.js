'use strict';
(function () {
    var app = angular.module("termeh");
    app.directive('confirmationModal', function () {
        return {
            restrict: 'E',
            scope: {
                approve: '&onApprove',
                deny: '&onDeny',
                closable: '=closable',
                title: '@title',
                itemid: '@id',
                confirm: '&onDeleteJob'
            },
            template: '<a href="javascript:;"><i class="circular red trash icon"></i></a><div class="ui small modal" id="modal">' +
                        '<div class="header"> {{title}}</div><div class="content"><div> Are you sure you want to delete this item?' +
                        '</div></div><div class="actions"><div ng-click="closeModal();deny();" class="ui negative button">No</div>' +
                        '<div class="ui positive right labeled icon button" ng-click="approve();">Yes <i class="checkmark icon"></i></div></div></div>',
            link: function (scope, element, attrs, ngModelCtrl) {

                element.on('click', function (e) {
                    $('#modal').modal({ 'closable': scope.closable }).modal('show');
                });
                scope.approve = function () {
                    var expressionHandler = scope.confirm();
                    expressionHandler(scope.itemid);
                };
            }
        };

        function closeModal() {
            $('#modal').modal('hide');
        }
    });
}());