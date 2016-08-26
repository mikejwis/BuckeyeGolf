(function () {
    'use strict';

    angular.module("app")
        .controller("AddResults", AddResults);

    AddResults.$inject = ['spinnerservice', 'dataservice', 'toastr', '$scope', '$state', '$stateParams'];

    function AddResults(spinnerservice, dataservice, toastr, $scope, $state, $stateParams) {
        var vm = this;
        vm.weekId = null;
        vm.data = {};
        vm.list = [];
        vm.newViewResults = [];
        vm.add = addNewResults;
        vm.sum = sumRow;

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getAddResults().then(function (result) {
                vm.data = result;
                var nbrOfPlayers = result.playerRounds.length;
                for (var i = 0; i < nbrOfPlayers; i++) {
                    vm.newViewResults.push({});
                }
                spinnerservice.stop();
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Error");
            });
        }

        function sumRow(list) {
            var total = 0;
            angular.forEach(list, function (item) {
                total += item;
            });
            return total;
        }

        function addNewResults(newResults) {
            spinnerservice.start();
            var newResultsInfo = vm.data;
            dataservice.addResults(newResultsInfo).then(
                function (result) {
                    spinnerservice.stop();
                    $state.go('results');
                }, function (error) {
                    spinnerservice.stop();
                    toastr.error(error, "Error");
                });
        }
    }
})();