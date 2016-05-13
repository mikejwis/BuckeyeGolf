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

//        var cachedItems = [];
//        var alreadyDownloaded = false;
        return service;

        function getLeaderboard() {
            var d = $q.defer();
            var results = {'weeksPlayed':1,'playerSummary':[
                {
                    'name': 'Keith',
                    'totalPoints': 12.5,
                    'scoreAvg': 43,
                    'currentHandicap':10,
                    'birds': 1,
                    'pars': 1,
                    'bogeys':5
                },
                {
                    'name': 'Len',
                    'totalPoints': 11,
                    'scoreAvg': 43,
                    'currentHandicap':9,
                    'birds': 0,
                    'pars': 3,
                    'bogeys':4
                },
                {
                    'name': 'Todd',
                    'totalPoints': 9.5,
                    'scoreAvg': 46,
                    'currentHandicap':13,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':5
                },
                {
                    'name': 'Mark',
                    'totalPoints': 9.5,
                    'scoreAvg': 50,
                    'currentHandicap':14,
                    'birds': 0,
                    'pars': 2,
                    'bogeys':3
                },
                {
                    'name': 'Kevin',
                    'totalPoints': 8.5,
                    'scoreAvg': 49,
                    'currentHandicap':16,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':3
                },
                {
                    'name': 'Brandon',
                    'totalPoints': 6.5,
                    'scoreAvg': 54,
                    'currentHandicap':19,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':3
                },
                {
                    'name': 'Tom S',
                    'totalPoints': 6,
                    'scoreAvg': 47,
                    'currentHandicap':11,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':4
                },
                {
                    'name': 'Bill',
                    'totalPoints': 6,
                    'scoreAvg': 56,
                    'currentHandicap':20,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':2
                },
                {
                    'name': 'Jack',
                    'totalPoints': 5,
                    'scoreAvg': 53,
                    'currentHandicap':16,
                    'birds': 0,
                    'pars': 1,
                    'bogeys':2
                },
                {
                    'name': 'Emil',
                    'totalPoints': 3.5,
                    'scoreAvg': 71,
                    'currentHandicap':31,
                    'birds': 0,
                    'pars': 0,
                    'bogeys':1
                },
                {
                    'name': 'Mike',
                    'totalPoints': 3,
                    'scoreAvg': 61,
                    'currentHandicap':18,
                    'birds': 0,
                    'pars': 0,
                    'bogeys':0
                },
                {
                    'name': 'David',
                    'totalPoints': 1,
                    'scoreAvg': 0,
                    'currentHandicap':9,
                    'birds': 0,
                    'pars': 0,
                    'bogeys':0
                }
            ]};
            d.resolve(results);
            return d.promise;
        }

        function getResults() {
            //var d = $q.defer();
            //$http.get('/api/TestData').then(function (results) {
            //    d.resolve(results.data);
            //}, function (error) {
            //    toastr.error(error, 'Error');
            //    d.reject(error);
            //});

            //return d.promise;

            var d = $q.defer();
            var results = [{'weekNbr':1, 'scoreCreateDate':'5/10/2016','playerRounds':[
                {
                    'name':'Keith',
                    'totalScore':43,
                    'totalPoints':12.5,
                    'birdies':1,
                    'pars':1,
                    'bogeys':5
                },
                { 
                    'name':'Mark',
                    'totalScore':50,
                    'totalPoints':9.5,
                    'birdies':0,
                    'pars':2,
                    'bogeys':3
                },
                {
                    'name':'Len',
                    'totalScore':43,
                    'totalPoints':11,
                    'birdies':0,
                    'pars':3,
                    'bogeys':4
                },
                {
                    'name':'Mike',
                    'totalScore':61,
                    'totalPoints':3,
                    'birdies':0,
                    'pars':0,
                    'bogeys':0
                },
                {
                    'name':'Kevin',
                    'totalScore':49,
                    'totalPoints':8.5,
                    'birdies':0,
                    'pars':1,
                    'bogeys':3
                },
                {
                    'name':'Brandon',
                    'totalScore':54,
                    'totalPoints':6.5,
                    'birdies':0,
                    'pars':1,
                    'bogeys':3
                },
                {
                    'name':'Tom S',
                    'totalScore':47,
                    'totalPoints':6,
                    'birdies':0,
                    'pars':1,
                    'bogeys':4
                },
                {
                    'name':'Todd',
                    'totalScore':46,
                    'totalPoints':9.5,
                    'birdies':0,
                    'pars':1,
                    'bogeys':5
                },
                {
                    'name':'David',
                    'totalScore':0,
                    'totalPoints':1,
                    'birdies':0,
                    'pars':0,
                    'bogeys':0
                },
                {
                    'name':'Bill',
                    'totalScore':56,
                    'totalPoints':6,
                    'birdies':0,
                    'pars':1,
                    'bogeys':2
                },
                {
                    'name':'Emil',
                    'totalScore':71,
                    'totalPoints':3.5,
                    'birdies':0,
                    'pars':1,
                    'bogeys':1
                },
                {
                    'name':'Jack',
                    'totalScore':53,
                    'totalPoints':5,
                    'birdies':0,
                    'pars':1,
                    'bogeys':2
                }
            ]}];
            d.resolve(results);
            return d.promise;
        }

        function getMatchups() {
            var d = $q.defer();
            var results = [{'weekNbr': 2, 'matchups':
                            [{
                                'player1Name': 'Mike',
                                'player1Handicap': 18,
                                'player2Name': 'David',
                                'player2Handicap': 9
                            },{
                                'player1Name': 'Bill',
                                'player1Handicap':20,
                                'player2Name': 'Len',
                                'player2Handicap':9
                            },
                            {
                                'player1Name': 'Brandon',
                                'player1Handicap':19,
                                'player2Name': 'Emil',
                                'player2Handicap':31
                            },
                            {
                                'player1Name': 'Keith',
                                'player1Handicap':10,
                                'player2Name': 'Mark',
                                'player2Handicap':14
                            },
                            {
                                'player1Name': 'Kevin',
                                'player1Handicap':16,
                                'player2Name': 'Jack',
                                'player2Handicap':16
                            },
                            {
                                'player1Name': 'Tom S',
                                'player1Handicap':11,
                                'player2Name': 'Todd',
                                'player2Handicap':13
                            }]
                        },
                        { 'weekNbr': 1, 'matchups': 
                            [{
                                'player1Name': 'Jack',
                                'player1Handicap':15,
                                'player2Name': 'Mark',
                                'player2Handicap':14
                            }, 
                            {
                                'player1Name': 'Len',
                                'player1Handicap':10,
                                'player2Name': 'David',
                                'player2Handicap':9
                            },
                            {
                                'player1Name': 'Tom S',
                                'player1Handicap':11,
                                'player2Name': 'Keith',
                                'player2Handicap':11
                            },
                            {
                                'player1Name': 'Todd',
                                'player1Handicap':14,
                                'player2Name': 'Emil',
                                'player2Handicap':31
                            },
                            {
                                'player1Name': 'Mike',
                                'player1Handicap':15,
                                'player2Name': 'Kevin',
                                'player2Handicap':17
                            },
                            {
                                'player1Name': 'Brandon',
                                'player1Handicap':20,
                                'player2Name': 'Bill',
                                'player2Handicap':22
                            }] 
                        }];
            d.resolve(results);
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