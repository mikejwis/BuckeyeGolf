(function () {
    'use strict';

    angular.module("app")
        .controller("Matchups", Matchups);

    Matchups.$inject = ['dataservice','$scope', '$state', '$stateParams'];

    function Matchups(dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};
        vm.newMatchups = [];

        Activate();

        function Activate() {
            dataservice.getMatchups().then(function (result) {
                vm.data = result;
                var nbrOfMatchups = result.players.length / 2;
                for(var i =0; i<nbrOfMatchups;i++)
                {
                    vm.newMatchups.push({});
                }
            //    toastr.info(data,"Data Received");
            });
        }
    }
})();