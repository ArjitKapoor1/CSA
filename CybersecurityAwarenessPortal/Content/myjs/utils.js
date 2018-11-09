var utils = new Utils();

function Utils(){
	
	this.getTime = function(){
		return (new Date()).getTime();
	};
	
	this.getARGBString = function(a,r,g,b){
		return "rgba("+
			Math.floor(255*r)+","+
			Math.floor(255*g)+","+
			Math.floor(255*b)+","+
			Math.floor(255*a)+")";
	};
	
}
