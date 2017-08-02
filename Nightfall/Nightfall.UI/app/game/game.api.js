(function () {
    angular
        .module('moritz.nightfall.game')
        .factory('gameApi', ['eventService', '$location', '$http', function (eventService, $location, $http) {

            return {
                createNewGame: function (gameName) {
                    $http.post(url + '/api/games/', gameName);
                }
            }
        }])
})();