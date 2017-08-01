(function () {
    angular
        .module('moritz.nightfall.player')
        .controller('PlayerCtrl', ['$rootScope', 'eventService', 'zoneApi', function ($rootScope, eventService, zoneApi) {
            ////VARIABLES
            var vm = this;
            vm.player = { name: 'Player', archetype: 'Champion', nativeZone: 'Home' };
            vm.zones = {};

            ////LISTENERS
            $rootScope.$on('champctrl:select', function (event, data) {
                console.log('playerlistener', event, data);
            })

            ////INTERFACE
            vm.savePlayer = savePlayer;

            ////IMPLEMENTATION
            function savePlayer() {
                playerApi.save(player).then(function (response) {
                    console.log("player saved!");
                },
                function (error) {
                    console.log("Error saving player: " + error);
                });
            }


            ////HELPER METHODS
            function activate() {
                var champion = eventService.consume('champctrl:select');
                if (Object.keys(champion).length > 0) {
                    vm.player.archetype = champion;
                }
                zoneApi.getAll().then(function (response) {
                    vm.zones = response.data;
                },
                function (error) {
                    console.log("Error retrieving zones.", error);                
                })
            }

            ////ACTIVATION
            activate();
        }]);
})();