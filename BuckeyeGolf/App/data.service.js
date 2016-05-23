(function () {
    'use strict';

    angular.module("app").factory("dataservice", dataservice);

    dataservice.$inject = ['toastr', '$q', '$http'];

    function dataservice(toastr, $q, $http) {
        var service = {
            getLeaderboard: getLeaderboard,
            getResults: getResults,
            getMatchups: getMatchups,
            addMatchups: addMatchups,
            addResults: addResults,
            addPlayer: addPlayer,
            getPlayer: getPlayer
        };

        var cachedMatchups = [];
        var matchupsDownloaded = false;
        return service;

        function getLeaderboard() {
            var d = $q.defer();
            $http.get('/api/Leaderboard').then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                toastr.error(error, 'Error');
                d.reject(error);
            });
            return d.promise;
        }

        function getResults() {
            var d = $q.defer();
            $http.get('/api/Results').then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                toastr.error(error, 'Error');
                d.reject(error);
            });
            return d.promise;
        }

        function getMatchups() {
            var d = $q.defer();
            if (matchupsDownloaded) {
                d.resolve(cachedMatchups);
            } else {
                $http.get('/api/Matchups').then(function (results) {
                    cachedMatchups = results.data;
                    //turning off for now until caching invalidation implemented
                    //matchupsDownloaded = true;
                    d.resolve(results.data);
                }, function (error) {
                    toastr.error(error, 'Error');
                    d.reject(error);
                });
            }
            return d.promise;
        }

        function addMatchups() {

        }

        function addResults() {

        }

        function addPlayer() {

        }

        function getPlayer() {

        }
    }
})();