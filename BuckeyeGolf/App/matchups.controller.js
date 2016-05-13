(function () {
    'use strict';

    angular.module("app")
        .controller("Matchups", Matchups);

    Matchups.$inject = ['dataservice','$scope', '$state', '$stateParams'];

    function Matchups(dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.list = [];

        Activate();

        function Activate() {
            dataservice.getMatchups().then(function (data) {
                vm.list = data;
            //    toastr.info(data,"Data Received");
            });
        }
    }
})();