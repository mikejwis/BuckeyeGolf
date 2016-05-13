(function () {
    'use strict';

    angular.module("app")
        .controller("Leaderboard", Leaderboard);

    Leaderboard.$inject = ['dataservice', '$scope', '$state', '$stateParams'];

    function Leaderboard(dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};

        Activate();

        function Activate() {
            dataservice.getLeaderboard().then(function (result) {
                vm.data = result;
                //   toastr.info(data,"Data Received");
            });
        }
    }
})();