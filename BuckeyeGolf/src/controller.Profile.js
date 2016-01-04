'use strict';

(function () {
    angular.module('golfApp')
        .controller('ProfileCtrl', ProfileCtrl)

    ProfileCtrl.$inject = ['chartSvc', '$scope', '$q', '$http'];

    function ProfileCtrl(chartSvc, $scope, $q, $http) {
        var vm = this;
        vm.test = "hi";
        $scope.blah = "hi";

        $scope.addRound = function (newRound) {
            $scope.newRound = newRound;
            //call server API here to post a new round
            var currentRounds = $scope.rounds;
            var newItem = { "weekNbr": newRound.weekNbr, "points": newRound.points, "score": newRound.score };
            currentRounds.push(newItem);
            drawChart(currentRounds);
        };

        function getRoundsForPlayer() {
            var d = $q.defer();
            $http.get('/api/rounds').then(function (r) {
                d.resolve(r.data);
            });
            return d.promise;
        }

        function drawChart(roundData) {
            $scope.rounds = roundData;

            chartSvc.loadChartObjects(roundData).then(function (d) {
                var options = {
                    hAxis: {
                        title: 'Week'
                    },
                    vAxis: {
                        title: 'Score'
                    }
                };
                var chartDiv = document.getElementById('chart_div');
                chartDiv.innerHTML = "";
                var chart = new google.visualization.LineChart(chartDiv);
                chart.draw(d, options);
            });
        }

        getRoundsForPlayer().then(drawChart);
    }
})();