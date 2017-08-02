(function () {
    angular
        .module('moritz.nightfall.game')
        .controller('GameCtrl', ['eventService', 'gameApi', function (eventService, gameApi) {
            ////VARIABLES
            var vm = this;
            vm.showGameCreateUi = false;

            ////INTERFACE
            vm.createGame = createGame;

            ////IMPLEMENTATION
            function createGame() {
                console.log('create');
                gameApi.createGame(createGameAddCommand());
            }

            ////HELPER METHODS
            function createGameAddCommand() {
                return {
                    Name: vm.gameName
                };
            }

            ////ACTIVATION
        }]);
})();