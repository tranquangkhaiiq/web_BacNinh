/* config.js */
params.PageBgColor = params.PageBgColor||"#d7d7d7";

slideshow_css = '$CssPath$style.css';
thumbs = {margin: 3, padding: 1};

files.push({ 'src': 'backgnd/'+params.TemplateName+'/fonts/ws-ctrl-convex.eot', dest: '$CssPath$ws-ctrl-convex.eot' });
files.push({ 'src': 'backgnd/'+params.TemplateName+'/fonts/ws-ctrl-convex.svg', dest: '$CssPath$ws-ctrl-convex.svg' });
files.push({ 'src': 'backgnd/'+params.TemplateName+'/fonts/ws-ctrl-convex.ttf', dest: '$CssPath$ws-ctrl-convex.ttf' });
files.push({ 'src': 'backgnd/'+params.TemplateName+'/fonts/ws-ctrl-convex.woff', dest: '$CssPath$ws-ctrl-convex.woff' });


if (params.Thumbnails || params.ShowBullets){
	params.ThumbWidthHalf = Math.round(params.ThumbWidth/2);
	files.push( { 'src': 'backgnd/'+params.TemplateName+'/style-tooltip.css', 'dest': slideshow_css, 'filters': ['params'] } );
}


params.addCss += [
	"",
	"@font-face {",
	"  font-family: 'ws-ctrl-convex';",
	"  src: url('ws-ctrl-convex.eot');",
	"  src: url('ws-ctrl-convex.eot#iefix') format('embedded-opentype'),",
	"       url('ws-ctrl-convex.svg#ws-ctrl-convex') format('svg');",
	"  font-weight: normal;",
	"  font-style: normal;",
	"}",
	"@font-face {",
	"  font-family: 'ws-ctrl-convex';",
	"  src: url('data:application/octet-stream;base64,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') format('woff'),",
	"       url('data:application/octet-stream;base64,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') format('truetype');",
	"}"
].join('\n');


// call this function at the end of each template
finalize();