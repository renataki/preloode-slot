function resizeContainer() {
	
	var height = 0;
	var width = 0;
	var resolutionHeight = [
		1440,
		1080,
		900,
		765,
		720,
		576,
		552,
		507,
		450,
		432,
		360,
		338,
		270,
		203,
		180
	];
	var resolutionWidth = [
		2560,
		1920,
		1600,
		1360,
		1280,
		1024,
		980,
		900,
		800,
		768,
		640,
		600,
		480,
		360,
		320
	];
	
	for(var i = 0; i < resolutionWidth.length; i++) {
		
		if(window.innerWidth >= resolutionWidth[i] && window.innerHeight >= resolutionHeight[i]) {
			
			height = resolutionHeight[i];
			width = resolutionWidth[i];
			
			break;
			
		}
		
	}

	document.getElementById("container").style.height = height + "px";
	document.getElementById("container").style.width = width + "px";

	var margin = (window.innerHeight - height) / 2;
	document.getElementById("container").style.margin = margin + "px auto 0 auto";
	
}


document.addEventListener("DOMContentLoaded", function(event) {

	
	resizeContainer();
	
	
});


window.addEventListener("resize", function () {
	
	
	resizeContainer();
	
	
});
