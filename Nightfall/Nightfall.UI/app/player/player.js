(function () {
    angular
        .module('moritz.nightfall.player')
        .controller('PlayerCtrl', ['zoneApi', 'playerApi', function (zoneApi, playerApi) {
            ////VARIABLES
            var vm = this;
            vm.player = { name: '', archetype: '', nativeZone: '' };
            vm.zones = {};

            ////LISTENERS

            ////INTERFACE
            vm.save = save;

            ////IMPLEMENTATION
            function save() {
                playerApi.save(vm.player).then(function (response) {
                    console.log("player saved!");
                },
                function (error) {
                    console.log("Error saving player: " + error);
                });
            }


            ////HELPER METHODS
            function activate() {
                vm.player.archetype = playerApi.consumeSelectedChampion();
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