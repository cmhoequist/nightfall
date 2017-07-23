(function() {
    var hyperstream = require('hyperstream');
    var fs = require('fs');

    var magic = hyperstream({
        'head': {
            _appendHtml: '<script src="/test"></script>\r\n',
        }
    });

    var output = fs.createReadStream(__dirname + '/index.html');
    output.pipe(magic).pipe(process.stdout);
})();