'use strict';

//Bootstrap angular instead of including in html to allow google charts to load first

google.setOnLoadCallback(function () {
    angular.bootstrap($('body'), ['app']);
});

google.load('visualization', '1', { packages: ['corechart', 'line'] });


