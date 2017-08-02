(function(){
    angular
        .module('moritz.nightfall')
        .factory('eventService', ['$rootScope', function ($rootScope) {
            var messages = {};
            var subscribers = {};

            return {
                publish: function (title, data) {
                    console.log('publishing', title, data);
                    if (!messages[title]) {
                        messages[title] = [];
                    }
                    if (subscribers[title]) {
                        for (var callback in subscribers[title]) {
                            callback(data);
                        }
                    }
                    else {
                        messages[title].push(data);
                    }
                },
                subscribe: function (title, fnCallback) {
                    if (!subscribers[title]) {
                        subscribers[title] = [];
                    }
                    subscribers[title].push(fnCallback);
                },
                consume: function (title) {
                    var response = [];
                    if (messages[title]) {
                        response = messages[title].slice(0);
                    }
                    messages[title] = null;
                    return response;
                },
                read: function (title) {
                    var response = [];
                    if (messages[title]) {
                        response = messages[title].slice(0);
                    }
                    return response;
                }
            };
        }]);
})();
