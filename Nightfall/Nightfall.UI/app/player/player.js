(function () {
    angular
        .module('moritz.nightfall.player')
        .controller('PlayerCtrl', ['zoneApi', 'playerApi', function (zoneApi, playerApi) {
            ////VARIABLES
            var vm = this;
            vm.player = { Name: '', Archetype: {}};
            vm.zones = {};

            ////LISTENERS

            ////INTERFACE
            vm.save = save;

            ////IMPLEMENTATION
            function save() {
                playerApi.save(createPlayerAddCommand()).then(function (response) {
                    if (response !== null) {
                        console.log("player saved!");
                    }
                });
            }


            ////HELPER METHODS
            function activate() {
                vm.player.Archetype = playerApi.consumeSelectedChampion();
                vm.player.Game = playerApi.readCurrentGame();
                zoneApi.getAll().then(function (response) {
                    vm.zones = response.data;
                },
                function (error) {
                    console.log("Error retrieving zones.", error);                
                });
            }

            function createPlayerAddCommand() {
                return {
                    Name: vm.player.Name,
                    ChampionId: vm.player.Archetype.Id,
                    ZoneId: vm.player.ZoneId,
                    GameId: vm.player.Game.Id
                };
            }

            ////ACTIVATION
            activate();
        }]);
})();