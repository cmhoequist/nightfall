(function(){
    angular
        .module('moritz.nightfall.player')
        .factory('playerApi', ['eventService', 'config', '$http', function (eventService, config, $http) {
            var url = config.apiBaseUrl;

            function consumeTopic(topic) {
                var result = eventService.consume(topic);
                if (result.length < 1) {
                    console.log('No messages found on ' + topic + '!');
                }
                return result;
            }

            function readTopic(topic) {
                var result = eventService.read(topic);
                if (result.length < 1) {
                    console.log('No messages found on ' + topic + '!');
                }
                return result;
            }

            return {
                save: function (player) {
                    return $http.post(url + '/api/players/', player)
                        .then(function (response) {
                            eventService.publish(config.topics.createPlayer, player);
                            return response.data;
                        },
                        function (error) {
                            console.log('Error saving player: ', error);
                            return null;
                        });
                },
                listen: function (topic, fnCallback) {
                    eventService.subscribe(topic, fnCallback);
                },
                consumeSelectedChampion: function () {
                    return consumeTopic(config.topics.selectChampion)[0];
                },
                readCurrentGame: function () {
                    return readTopic(config.topics.createGame)[0];
                }
            };
        }]);
})();