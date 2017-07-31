(function () {
    var gulp = require('gulp'),
        inject = require('gulp-inject'),
        replace = require('gulp-replace'),
        fs = require('fs');

    var appJsOrder = [
        "./app/module.js",
        "./app/config.js",
        "./app/routing.js",
        "./app/**/*.module.js",
        "./app/**/*.api.js",
        "./app/**/!( module.js | config.js | routing.js | *.module.js | *.api.js)*.js"
    ];

    var nodeModulesJsOrder = [
        "./node_modules/**/dist/jquery.js",
        "./node_modules/**/angular.js",
        "./node_modules/**/angular-route.js",
        "./node_modules/**/angular-animate.js",
        "./node_modules/**/angular-aria.js",
        "./node_modules/**/angular-material.js"
    ];

    var cssOrder = [
        "./node_modules/**/angular-material.css",
        "./node_modules/**/font-awesome.css",
        "./content/styles.css"
    ];

    var fonts = [
        "./content/fonts/*.woff"
    ];

    gulp.task('injectAll', function () {
        var target = gulp.src('./index.html'),
            nodeSources = gulp.src(nodeModulesJsOrder, { read: false }),
            otherSources = gulp.src(appJsOrder.concat(cssOrder), { read: false });

        return target
            .pipe(inject(nodeSources, { starttag: '<!--inject:nodemodules:js-->' }), { relative: true })
            .pipe(inject(otherSources), { relative: true })
            .pipe(gulp.dest('./'));
    });

    gulp.task('injectFonts', function () {
        var target = gulp.src('./content/styles.css');

        return target
            .pipe(replace(/\/\*inject-fonts\*\/[\s\S]*\/\*endinject\*\//, function (match) {
                return '/*inject-fonts*/' + buildFontFace() + '\n/*endinject*/';
            }))
            .pipe(gulp.dest('./content/'));
    })

    function buildFontFace() {
        var rootDir = process.cwd();
        var outcome = '';
        fs.readdirSync(rootDir + '/content/fonts/').forEach(function (file) {
            var fontName = file.slice(0, file.search(/[_-]/));
            outcome +=
                '\n\n@font-face {' +
                '\n\tfont-family: \'' + fontName.charAt(0).toUpperCase() + fontName.slice(1) + '\';' +
                '\n\tsrc: url(\'fonts/' + file + '\') format(\'woff\');' +
                '\n}\n'
        });
        return outcome;
    }

    gulp.task('gulpBuild', ['injectAll', 'injectFonts']);
})();
