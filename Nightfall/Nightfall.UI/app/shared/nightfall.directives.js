(function () {
    angular
        .module('moritz.nightfall')
        //.directive('someDir', function(){});
        .directive('hoverable', function () {
            return {
                restrict: 'E',
                transclude: true,
                scope: {
                    hoverColor: '@hoverColor',
                    direction: '@layout',
                    align: '@layoutAlign',
                    pad: '@pad',
                    margin: '@margin',
                    noSize: '@noSize'
                },
                template: '<div flex="100" ng-class="{\'layout-margin\': margin, \'layout-padding\': pad}" layout="{{layout}}" layout-align="{{align}}" ng-transclude></div>',
                link: function (scope, element, attrs) {
                    var originalColor = "";
                    var originalFont = "";

                    element
                        .on('mouseenter', function () {
                            originalColor = element.css('color');
                            originalFont = element.css('font-size');
                            element.css('color', scope.hoverColor);
                            if (!scope.noSize) {
                                element.css('font-size', '24px');
                            }
                        })
                        .on('mouseleave', function () {
                            element.css('color', originalColor);
                            element.css('font-size', originalFont);
                        });
                }
            }
        });
})();