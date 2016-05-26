(function () {
    'use strict';

    angular.module("app")
        .controller("Matchups", Matchups);

    Matchups.$inject = ['spinnerservice', 'dataservice','$scope', '$state', '$stateParams'];

    function Matchups(spinnerservice, dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};
        vm.newMatchups = [];

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getMatchups().then(function (result) {
                vm.data = result;
                var nbrOfMatchups = result.players.length / 2;
                for(var i =0; i<nbrOfMatchups;i++)
                {
                    vm.newMatchups.push({});
                }
                spinnerservice.stop();
            //    toastr.info(data,"Data Received");
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Failure on Retrieving Data");
            });
        }
    }
})();