(function () {
    'use strict';

    angular.module("app").factory("dataservice", dataservice);

    dataservice.$inject = ['toastr', '$q', '$http'];

    function dataservice(toastr, $q, $http) {
        var service = {
            getLeaderboard: getLeaderboard,
            getResults: getResults,
            getAddResults: getAddResults,
            getMatchups: getMatchups,
            getAddMatchups: getAddMatchups,
            addMatchups: addMatchups,
            addResults: addResults,
            addPlayer: addPlayer,
            getPlayerDetails: getPlayer
        };

        var cachedMatchups = [];
        var matchupsDownloaded = false;
        return service;

        function getLeaderboard() {
            var d = $q.defer();
            $http.get('/api/Leaderboard').then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                //toastr.error(error, 'Error');
                d.reject(error);
            });
            return d.promise;
        }

        function getResults() {
            var d = $q.defer();
            $http.get('/api/Results').then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                //toastr.error(error, 'Error');
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
                    //toastr.error(error, 'Error');
                    d.reject(error);
                });
            }
            return d.promise;
        }

        function getAddMatchups() {
            var d = $q.defer();
            if (matchupsDownloaded) {
                d.resolve(cachedMatchups);
            } else {
                $http.get('/api/Matchups/Add').then(function (results) {
                    cachedMatchups = results.data;
                    //matchupsDownloaded = true;
                    d.resolve(results.data);
                }, function (error) {
                    //toastr.error(error, 'Error');
                    d.reject(error);
                });
            }
            return d.promise;
        }

        function getAddResults() {
            var d = $q.defer();
            $http.get('/api/Results/Add').then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                d.reject(error);
            });
            return d.promise;
        }

        function addMatchups(postData) {
            var d = $q.defer();
            postData = postData || {};
            $http.post('/api/Matchups/Add', postData).then(
                function (r) {
                    d.resolve(r.data);
                },
                function (e) {
                    console.log(e);
                    if (e.status === 400) {
                        d.reject("Validation failed at the server");
                    }
                });
            return d.promise;
        }

        function addResults(postData) {
            var d = $q.defer();
            postData = postData || {};
            $http.post('/api/Results/Add', postData).then(
                function (r) {
                    //cachedItems.push(cleanUp(r.data));
                    d.resolve(r.data);
                },
                function (e) {
                    console.log(e);
                    if (e.status === 400) {
                        d.reject("Validation failed at the server");
                    }
                });
            return d.promise;
        }


        function addPlayer() {

        }

        function getPlayer(getParams) {
            var d = $q.defer();
            $http.get('/api/Player/' + getParams).then(function (results) {
                d.resolve(results.data);
            }, function (error) {
                d.reject(error);
            });
            return d.promise;
        }
    }
})();