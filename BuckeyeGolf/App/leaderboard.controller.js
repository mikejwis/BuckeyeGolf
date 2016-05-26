﻿(function () {
    'use strict';

    angular.module("app")
        .controller("Leaderboard", Leaderboard);

    Leaderboard.$inject = ['spinnerservice', 'dataservice', '$scope', '$state', '$stateParams'];

    function Leaderboard(spinnerservice, dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getLeaderboard().then(function (result) {
                vm.data = result;
                spinnerservice.stop();
                //   toastr.info(data,"Data Received");
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Failure on Retrieving Data");
            });
        }
    }
})();