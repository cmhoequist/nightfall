(function () {
    angular
        .module('moritz.nightfall.champion')
        .factory('championApi', ['$http', 'config', 'eventService', '$location', function ($http, config, eventService, $location) {
            ////VARIABLES
            var url = config.apiBaseUrl;

            ////MAIN FACTORY FUNCTIONS
            return {
                getAll: function () {
                    return $http.get(url + '/api/champions/');
                },
                getDetails: function () {
                    return $http.get(url + '/api/champions/details');
                },
                selectChampion: function (data) {
                    eventService.publish(config.topics.selectChampion, data);
                    $location.path('/player/');
                }
            };
        }]);
})(); 