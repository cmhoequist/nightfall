(function () {
    angular
        .module('moritz.nightfall.game')
        .controller('GameCtrl', ['eventService', function (eventService) {
            ////VARIABLES
            var vm = this;
            vm.showGameCreateUi = false;

            ////INTERFACE
            
            vm.newGame = newGame;
            vm.loadGame = loadGame;

            ////IMPLEMENTATION
            function newGame() {

            }

            ////HELPER METHODS

            ////ACTIVATION
        }]);
})();