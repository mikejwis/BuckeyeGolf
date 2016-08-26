(function () {
    'use strict';

    angular.module("app")
        .controller("Player", Player);

    Player.$inject = ['chartservice', 'spinnerservice', 'dataservice', 'toastr', '$scope', '$state', '$stateParams'];

    function Player(chartservice, spinnerservice, dataservice, toastr, $scope, $state, $stateParams) {
        var vm = this;
        vm.list = {};

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getPlayerDetails($stateParams.pid).then(function (data) {
                vm.list = data;
                drawChart(vm.list.weeklyRounds);
                spinnerservice.stop();
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Error");
            });
        }

        function drawChart(roundData) {
            chartservice.loadChartObjects(roundData).then(function (d) {
                var options = {
                    hAxis: {
                        title: 'Week',
                        gridlines: {
                            count: roundData.length
                        }
                    },
                    title: 'Season Scoring',
                    pointSize: 4
                };
                var chartDiv = document.getElementById('chartDiv');
                chartDiv.innerHTML = "";
                var chart = new google.visualization.LineChart(chartDiv);
                chart.draw(d, options);
            });
        }
    }
})();