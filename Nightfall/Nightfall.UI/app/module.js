﻿(function () {
    angular.module('moritz.nightfall', [
        //Third party dependencies
        'ngAnimate',
        'ngRoute',
        'ngMaterial',

        //Project dependencies
        'moritz.nightfall.game',
        'moritz.nightfall.champion',
        'moritz.nightfall.player',
        'moritz.nightfall.zone',
    ]);
})();