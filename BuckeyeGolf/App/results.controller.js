(function () {
    'use strict';

    angular.module("app")
        .controller("Results", Results);

    Results.$inject = ['spinnerservice', 'dataservice','toastr','$scope', '$state', '$stateParams'];

    function Results(spinnerservice, dataservice, toastr, $scope, $state, $stateParams) {
        var vm = this;
        vm.list = [];

        Activate();

        function Activate() {
            spinnerservice.start();
            dataservice.getResults().then(function (data) {
                vm.list = data;
                spinnerservice.stop();
             //   toastr.info(data,"Data Received");
            }, function (err) {
                spinnerservice.show();
                toastr.error(err, "Failure on Retrieving Data");
            });
        }
    }
})();