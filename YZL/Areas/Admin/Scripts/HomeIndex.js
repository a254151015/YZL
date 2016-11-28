/// <reference path="../Views/Home/Index.html" />
//$(function () {

//    alert("aa");
//});
var app = angular.module("Test", ['ngRoute']);

app.controller("TestController", ["$scope", "$location", function ($scope, $location) {

    $scope.goToIndex2 = function () {
        $location.path("/SY");
    }
}]);
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/SY', { templateUrl: '../../Angular/Admin/Index.html', controller: 'TestController' })
        .otherwise({ redirectTo: '/SY' });
}]);

