(function () {
    'use strict';

    angular.module("app")
        .controller("AddMatchups", AddMatchups);

    AddMatchups.$inject = ['spinnerservice', 'dataservice', '$scope', '$state', '$stateParams'];

    function AddMatchups(spinnerservice, dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};
        vm.newMatchups = [];
        vm.nextWeekNbr = 0;
        vm.add = addNewMatchups;
        vm.delete = deleteMatchups;

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getAddMatchups().then(function (result) {
                vm.data = result;
                var nbrOfMatchups = result.players.length / 2;
                for (var i = 0; i < nbrOfMatchups; i++) {
                    vm.newMatchups.push({});
                }
                vm.nextWeekNbr = result.nextWeek;
                spinnerservice.stop();
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Error");
            });
        }

        function addNewMatchups(newMatchups) {
            spinnerservice.start();
            var newMatchupsInfo = { weekNbr: vm.nextWeekNbr, newPlayerMatchups: newMatchups };
            dataservice.addMatchups(newMatchupsInfo).then(
                function (result) {
                    spinnerservice.stop();
                    $state.go('matchups');
                }, function (err) {
                    spinnerservice.stop();
                    toastr.error(err, "Error");
                });
        }

        function deleteMatchups() {
            spinnerservice.start();
            //var newMatchupsInfo = { weekNbr: vm.nextWeekNbr, newPlayerMatchups: newMatchups };
            dataservice.deleteMatchups().then(
                function (result) {
                    spinnerservice.stop();
                    $state.go('matchups');
                }, function (err) {
                    spinnerservice.stop();
                    toastr.error(err, "Error");
                });
        }
    }
})();