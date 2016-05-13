(function () {
    'use strict';

    angular.module("app")
        .controller("Results", Results);

    Results.$inject = ['dataservice','toastr','$scope', '$state', '$stateParams'];

    function Results(dataservice, toastr, $scope, $state, $stateParams) {
        var vm = this;
        vm.list = [];

        Activate();

        function Activate() {
            dataservice.getResults().then(function (data) {
                vm.list = data;
             //   toastr.info(data,"Data Received");
            });
        }
    }
})();