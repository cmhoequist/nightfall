(function(){
    angular
        .module('moritz.nightfall')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: "app/game/landing.html"
                })
                .when('/player', {
                    templateUrl: "app/player/player.html"
                });
        }]);
})();