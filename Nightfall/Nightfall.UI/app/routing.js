(function(){
    angular
        .module('moritz.nightfall')
        .config(['$routeProvider', function ($routeProvider) {
            $routeProvider
                .when('/', {
                    templateUrl: "app/champion/championselect.html"
                });
        }]);
})();