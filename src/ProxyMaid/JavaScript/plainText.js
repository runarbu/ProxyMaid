var webPage = require('webpage');

var page = require('webpage').create(),
    system = require('system'),
    url;

// Timeout: Prevention slow pages to hang the application.
page.settings.resourceTimeout = 60000; // 60 seconds
page.onResourceTimeout = function(e) {
  console.log(e.errorCode);
  console.log(e.errorString);
  console.log(e.url);
  phantom.exit(1);
};
    
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