(function () {
    ////VARIABLES
    var fs = require('fs');
    var hyperstream = require('hyperstream');
    var rootDir = process.cwd();

    ////MAIN METHODS
    var appDependencies = (function (offset, rootDir) {
        var trunk = { 'app': [] };
        fs.readdirSync(rootDir + offset).forEach(function (file) {
            if (fs.lstatSync(rootDir + offset + file).isDirectory()) {
                merge(trunk, walkGeneric(offset + file + '/', rootDir, null, function (branch, offset, file) {
                    var suffix = file.slice(file.indexOf('.'));
                    if (!branch[suffix]) {
                        branch[suffix] = [];
                    }
                    branch[suffix].push(offset + file);
                }));
            }
            else {
                trunk['app'].push(offset + file);
            }
        });

        return ['app', '.module.js', '.api.js', '.js'].reduce(function (aggregate, cat) {
            if (trunk[cat]) {
                aggregate += scriptify(trunk[cat]);
            }
            return aggregate;
        }, "");
    })('/app/', rootDir);

    var nodeModuleDependencies = scriptify((function (offset, dependencies) {
        var outcome = walkGeneric(offset, rootDir, dependencies, function (branch, offset, file) {
            if (branch[file]) {
                branch[file].push(offset + file);
            }
        })
        var result = [];
        Object.keys(outcome).forEach(key => result.push(outcome[key][0]));
        return result;
    })('/node_modules/', ['jquery.js', 'bootstrap.js', 'angular.js']));

    ////HELPER METHODS
    function merge(src, child) {
        Object.keys(child).forEach(function (key) {
            if (!src[key]) {
                src[key] = [];
            }
            src[key] = src[key].concat(child[key]);
        });
    }

    function scriptify(jsPathList) {
        return [].concat(jsPathList.reduce(function (aggregate, leafPath) {
            return aggregate += '\t<script src="' + leafPath + '"></script>\n\t';
        }, "\n\t"));
    }

    function branchTemplate(dependencies) {
        var branch = {};
        if (dependencies) {
            dependencies.forEach(dep => branch[dep] = []);
        }
        return branch;
    }

    function walkGeneric(offset, rootDir, dependencies, baseCaseCallback) {
        var branch = branchTemplate(dependencies);
        fs.readdirSync(rootDir + offset).forEach(function (file) {
            if (fs.lstatSync(rootDir + offset + file).isDirectory()) {
                merge(branch, walkGeneric(offset + file + '/', rootDir, dependencies, baseCaseCallback));
            }
            else {
                baseCaseCallback(branch, offset, file);
            }
        });
        return branch;
    }

    ////ACTIVATION
    var magic = hyperstream({
        '#inject': {
            _html: nodeModuleDependencies + appDependencies,
        }
    });
    var output = fs.createReadStream(process.cwd() + '/index.html');
    output.pipe(magic).pipe(process.stdout);
})();