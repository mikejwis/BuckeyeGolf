(function () {
    'use strict';

    angular.module("app")
        .controller("Home", Home);

    Home.$inject = ['dataservice','$scope', '$state', '$stateParams'];

    function Home(dataservice, $scope, $state, $stateParams) {
        var vm = this;

        //var newMentor = {
        //    firstName: "",
        //    lastName: "",
        //    email: "",
        //    available: true
        //};

        //vm.newMentor = angular.copy(newMentor);

        //vm.add = function (mentor) {
        //    var mentorToAdd = angular.copy(mentor);
        //    mentorsData.add(mentorToAdd).then(
        //        function (addedMentor) {
        //            console.log("You added a mentor as ", addedMentor.id);
        //            vm.newMentor = angular.copy(newMentor);

        //            $state.go('default.mentors');
        //        }, function (error) {
        //            alert(error);
        //        });
        //};

        //mentorsData.getAll().then(function (data) {
        //    vm.list = data;
        //});

    }

})();
