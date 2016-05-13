(function () {
    'use strict';

    angular.module("app")
        .config([
            '$urlRouterProvider',
            '$stateProvider',
            function ($urlRouterProvider, $stateProvider) {
                $stateProvider.state("home", {
                    url: "/",
                    templateUrl: "/templates/home.html",
                    controller: "Home as vm"
                });
                $stateProvider.state("leaderboard", {
                    url: "/leaderboard",
                    templateUrl: "/templates/leaderboard.html",
                    controller: "Leaderboard as vm"
                });
                $stateProvider.state("matchups", {
                    url: "/matchups",
                    templateUrl: "/templates/matchups.html",
                    controller: "Matchups as vm"
                });
                $stateProvider.state("results", {
                    url: "/results",
                    templateUrl: "/templates/results.html",
                    controller: "Results as vm"
                });

                $urlRouterProvider.otherwise('/');
            }
        ]);
})();