(function () {
    angular.module('moritz.nightfall')
        .config(function ($mdThemingProvider) {
            $mdThemingProvider.definePalette('mBlack', customBlack);
            $mdThemingProvider.theme('custom-black')
                .primaryPalette('red')
                .accentPalette('red')
                .warnPalette('mBlack')
                .backgroundPalette('mBlack')
                .dark();
            $mdThemingProvider.setDefaultTheme('custom-black');

        })
        .service('config', Config);

    function Config() {
        this.apiBaseUrl = 'http://localhost:54526/';
    }

    var customBlack = {
        '50': 'e0e0e0',
        '100': 'b3b3b3',
        '200': '808080',
        '300': '4d4d4d',
        '400': '262626',
        '500': '000000',
        '600': '000000',
        '700': '000000',
        '800': '000000',
        '900': '000000',
        'A100': 'a6a6a6',
        'A200': '8c8c8c',
        'A400': '000000', //737373
        'A700': '666666',
        'contrastDefaultColor': 'light',
        'contrastDarkColors': [
            '50',
            '100',
            '200',
            'A100',
            'A200'
        ],
        'contrastLightColors': [
            '300',
            '400',
            '500',
            '600',
            '700',
            '800',
            '900',
            'A400',
            'A700'
        ]
    };
})();