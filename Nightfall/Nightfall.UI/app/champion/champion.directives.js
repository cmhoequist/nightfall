(function () {
    angular
        .module('moritz.nightfall.champion')
        .directive('championDisplay', function () {
            return {
                restrict: 'E',
                templateUrl: 'app/champion/champion-display.html'
            }
        });
})();