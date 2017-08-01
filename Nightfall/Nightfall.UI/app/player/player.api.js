(function(){
    angular
        .module('moritz.nightfall.player')
        .factory('playerApi', ['eventService', 'config', function (eventService, config) {
            function consumeTopic(topic) {
                var result = eventService.consume(topic);
                if (result.length < 1) {
                    result = ['Default'];
                }
                return result;
            }

            return {
                save: function (player) {
                    eventService.publish(config.topics.savePlayer, player);
                },
                listen: function (topic, fnCallback) {
                    eventService.subscribe(topic, fnCallback);
                },
                consumeSelectedChampion: function () {
                    return consumeTopic(config.topics.selectChampion)[0];                
                }
            }
        }]);
})();