(function () {
    angular
        .module('moritz.nightfall.champions')
        .controller('ChampCtrl', ['championApi', function (championApi) {
            ////VARIABLES
            var vm = this;
            vm.champions = ['Hierophant', 'Confessor', 'Vatessor', 'Ostiary'];

            ////INTERFACE
            vm.getChampions = getChampions();

            ////IMPLEMENTATION
            function getChampions() {
                championApi.getAll().then(function (response) {
                    vm.champions = response.data;
                }, function (err) {
                    console.log("Error: Could not get champions.");
                });
            }

            ////HELPER METHODS
            function activate() {
                getChampions();
            }

            ////ACTIVATION
            activate();
        }]);
})();