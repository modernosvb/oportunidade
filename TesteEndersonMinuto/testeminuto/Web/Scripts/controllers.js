'use strict';

// Google Analytics Collection APIs Reference:
// https://developers.google.com/analytics/devguides/collection/analyticsjs/

angular.module('app.controllers', [])

    // Path: /
    .controller('HomeCtrl', ['$scope', '$location', '$window', '$http', function ($scope, $location, $window, $http) {
        $scope.$root.title = 'Teste Minuto - Enderson Geraldine Torrano';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });

        var urlFeed = "http://www.minutoseguros.com.br/blog/feed/";

        $http.post('http://localhost:16576/api/Blog/ObterReumoConteudo?urlFeed=' + urlFeed)
            .success(function (data) {
                if (data == null) data = [];
                $scope.objs = data;
            })
            .error(function (data, status, headers, config) {
                alert('Erro no serviço - ' + status);
            });
    }])

    // Path: /error/404
    .controller('Error404Ctrl', ['$scope', '$location', '$window', function ($scope, $location, $window) {
        $scope.$root.title = 'Error 404: Page Not Found';
        $scope.$on('$viewContentLoaded', function () {
            $window.ga('send', 'pageview', { 'page': $location.path(), 'title': $scope.$root.title });
        });
    }]);