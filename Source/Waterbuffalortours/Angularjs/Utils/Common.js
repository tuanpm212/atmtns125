var app = angular.module('MyApp', ['ui.bootstrap', 'ngSanitize']);

app.controller('MainController', ['$scope', '$http', '$sce', function ($scope, $http, $sce)
{
    /*---Popup modal---*/
    $scope.modal = {
        modalAlert: {
            isShowModal: false,
            msgAlert: ''
        },
        modalConfirm: {
            isShowModal: false,
            msgConfirm: '',
        }
    };

    $scope.renderHtml = function (htmlCode) {
        return $sce.trustAsHtml(htmlCode);
    };

}]);