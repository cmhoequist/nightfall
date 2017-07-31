(function () {
    angular
        .module('moritz.nightfall.champion')
        .factory('championApi', ['$http', 'config', function ($http, config) {
            ////VARIABLES
            var url = config.apiBaseUrl;

            ////MAIN FACTORY FUNCTIONS
            return {
                getAll: function () {
                    return $http.get(url + '/api/champions/');
                },
                getDetails: function () {
                    return $http.get(url + '/api/champions/details');
                }
            }
        }]);
})();