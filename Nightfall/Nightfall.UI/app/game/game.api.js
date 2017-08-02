(function () {
    angular
        .module('moritz.nightfall.game')
        .factory('gameApi', ['eventService', '$location', '$http', 'config', function (eventService, $location, $http, config) {
            var url = config.apiBaseUrl;

            return {
                createGame: function (gameName) {
                    return $http.post(url + '/api/games/', gameName)
                        .then(function (response) {
                            eventService.publish(config.topics.createGame, response.data);
                            $location.path('/champion/');
                        },
                        function (error) {
                            console.log('Error creating game: ', error);
                            return null;
                        });
                }
            };
        }]);
})();