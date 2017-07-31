(function () {
    angular
        .module('moritz.nightfall.champion')
        .controller('ChampCtrl', ['championApi', '$rootScope', '$location', 'messageService', function (championApi, $rootScope, $location, messageService) {
            ////VARIABLES
            var vm = this;
            vm.champions = ['Hierophant', 'Confessor', 'Vatessor', 'Ostiary'];

            ////INTERFACE
            vm.getChampions = getChampions();
            vm.styleBanner = styleBanner;
            vm.selectChampion = selectChampion;

            ////IMPLEMENTATION
            function selectChampion(champion) {
                var data = champion.Name;
                messageService.publish('champctrl:select', data);
                $rootScope.$broadcast("champctrl:select", champion.Name);
                $location.path('/player/');
            }

            function getChampions() {
                championApi.getDetails().then(function (response) {
                    vm.champions = response.data;
                }, function (err) {
                    console.log("Error: Could not get champions.");
                });
            }

            function styleBanner(top, middle, bottom) {
                return "{'background': 'linear-gradient(" + top + ',' + middle + ',' + bottom + ")', 'height':'100%', 'padding':'1px', 'width':'33%'}";
            }

            ////HELPER METHODS
            function activate() {
                getChampions();
            }

            ////ACTIVATION
            activate();
        }]);
})();