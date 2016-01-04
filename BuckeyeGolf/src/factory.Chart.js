'use strict';

(function () {
    angular.module('golfApp').factory('chartSvc', chartSvc);

    chartSvc.$inject = ['$q'];

    function chartSvc($q) {
        var service = {
            loadChartObjects: loadChartObjects
        };
        return service;

        function loadChartObjects(roundsData) {
            var d = $q.defer();
            var data = new google.visualization.DataTable();
            data.addColumn('number', 'X');
            data.addColumn('number', 'Score');

            var arrayPts = roundsData.map(cleanUp);
            data.addRows(arrayPts);
            d.resolve(data);

            return d.promise;
        }

        function cleanUp(d) {
            var newItem = [d.weekNbr, d.score];
            return newItem;
        }
    };
})();