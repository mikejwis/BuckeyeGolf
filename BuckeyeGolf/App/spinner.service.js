(function () {
    'use strict';

    angular.module("app").factory("spinnerservice", spinnerservice);

    spinnerservice.$inject = ['jquery'];

    function spinnerservice(jquery) {
        var service = {
            start: start,
            stop: stop
        };

        return service;

        function start() {
            jquery('#spinner').toggleClass('hidden loading');
            //$('#spinner').toggleClass('hidden loading');
        }

        function stop() {
            jquery('#spinner').toggleClass('loading hidden');
           // $('#spinner').toggleClass('loading hidden');
        }

    }
})();