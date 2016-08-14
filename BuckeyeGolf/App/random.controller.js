(function () {
    'use strict';

    angular.module("app")
        .controller("Random", Random);

    Random.$inject = ['spinnerservice', 'dataservice', '$scope', '$state', '$stateParams'];

    function Random(spinnerservice, dataservice, $scope, $state, $stateParams) {
        var vm = this;
        vm.data = {};
        vm.newMatchups = [];

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getRandomMatchups($stateParams.weekNbr).then(function (result) {
                vm.data = result;
                spinnerservice.stop();
                //    toastr.info(data,"Data Received");
            }, function (err) {
                spinnerservice.stop();
                toastr.error(err, "Failure on Retrieving Data");
            });
        }
    }
})();