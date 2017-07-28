(function () {
    angular.module('moritz.nightfall')
        .config(function ($mdThemingProvider) {
            $mdThemingProvider.theme('default')
                .dark();
        })
        .service('config', Config);

    function Config() {
        this.apiBaseUrl = 'http://localhost:54526/';
    }

})();