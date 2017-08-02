(function () {
    angular
        .module('moritz.nightfall.game')
        .controller('GameCtrl', ['eventService', function (eventService) {
            ////VARIABLES
            var vm = this;
            vm.showGameCreateUi = false;

            ////INTERFACE
            vm.createNewGame = createNewGame;

            ////IMPLEMENTATION
            function createNewGame() {
                gameApi.createNewGame(vm.gameName);
            }

            ////HELPER METHODS

            ////ACTIVATION
        }]);
})();