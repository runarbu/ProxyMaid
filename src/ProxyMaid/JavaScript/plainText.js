var webPage = require('webpage');

var page = require('webpage').create(),
    system = require('system'),
    url;
	
if (system.args.length != 2) {
    console.log('Usage: plainText.js URL');
    phantom.exit(1);
} else {
    var url = system.args[1];

	page.open(url, function (status) {
	  console.log('Stripped down page text:\n' + page.plainText);
	  phantom.exit();
	});

}