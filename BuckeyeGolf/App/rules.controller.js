(function () {
    'use strict';

    angular.module("app")
        .controller("Rules", Rules);

    Leaderboard.$inject = ['spinnerservice', 'dataservice', '$scope', '$state', '$stateParams'];

    function Leaderboard(spinnerservice, dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};

        Activate();

        function Activate() {
        }
    }
})();