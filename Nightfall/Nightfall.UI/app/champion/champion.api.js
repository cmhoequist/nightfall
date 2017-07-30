(function () {
    angular
        .module('moritz.nightfall.champions')
        .factory('championApi', ['$http', 'config', function ($http, config) {
            ////VARIABLES
            var url = config.apiBaseUrl;

            ////MAIN FACTORY FUNCTIONS
            return {
                getAll: function () {
                    return $http.get(url + '/api/champions/all');
                },
                getDetails: function () {
                    return $http.get(url + '/api/champions/details');
                }
            }
        }]);
})();