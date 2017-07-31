(function() {
    angular
        .module('moritz.nightfall.zone')
        .factory('zoneApi', ['$http', 'config', function ($http, config) {
            var url = config.apiBaseUrl;

            return {
                getAll: function () {
                    return $http.get(url + '/api/zones/');
                }
            }
        }]);
})();