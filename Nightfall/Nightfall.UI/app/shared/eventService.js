(function(){
    angular
        .module('moritz.nightfall')
        .factory('eventService', ['$rootScope', function ($rootScope) {
            var messages = {};

            return {
                publish: function (title, data) {
                    if (!messages[title]) {
                        messages[title] = [];
                    }
                    messages[title].push(data);
                    $rootScope.$broadcast(title, data);
                },
                consume: function (title) {
                    if (messages[title]) {
                        return messages[title].shift();
                    }
                    return {};
                },
                consumeAll: function (title) {
                    var response = [];
                    if (messages[title]) {
                        response = messages[title].slice(0);
                    }
                    messages[title] = null;
                    return response;
                }
            }
        }]);
})();
