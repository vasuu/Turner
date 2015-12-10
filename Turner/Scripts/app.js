

var TitlesApp = angular.module("TitlesApp", ["ngRoute", "ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: TitlesController, templateUrl: 'list.html' }).
            when('/detail/:itemId', { controller: DetailController, templateUrl: 'detail.html' }).
            otherwise({ redirectTo: '/' });
    });

TitlesApp.factory('Title', function ($resource) {
    return $resource('/api/titles/:id', { id: '@id' }); //, { update: { method: 'PUT' } }
    //return $http.get('/api/titles/:id', { id: '@id' });
});

TitlesApp.factory('TitleDetails', function ($resource) {
    return $resource('/api/titledetails/:id', { id: '@id' }); //, { update: { method: 'PUT' } }
});

var TitlesController = function ($scope, $location, Title) {

    $scope.reset = function () {
        $scope.items = Title.query({ q: $scope.searchValue });
    };

    $scope.reset();
};

var DetailController = function ($scope, $routeParams, $location, TitleDetails) {
    $scope.item = TitleDetails.get({ id: $routeParams.itemId });

};
