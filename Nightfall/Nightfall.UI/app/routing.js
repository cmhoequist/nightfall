(function(){
    angular
        .module('moritz.nightfall')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: "app/game/landing.html"
                })
                .when('/champion', {
                    templateUrl: "app/champion/championselect.html"
                })
                .when('/player', {
                    templateUrl: "app/player/player.html"
                });
        }]);
})();