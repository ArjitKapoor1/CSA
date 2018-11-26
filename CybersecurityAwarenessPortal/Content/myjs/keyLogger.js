var keyLogger = new KeyLogger();

function KeyLogger(){
	
	this.keyStatus = {up:false,down:false,left:false,right:false,fire:false};
	this.keyDownListener = function(e){
		var key = e.keyCode ? e.keyCode : e.which;
		switch(key){
		
		case 87:
		case 38:
		//Up
			keyLogger.keyStatus.up = true;
		break;
		case 83:
		case 40:
		//Down
			keyLogger.keyStatus.down = true;
		break;
		case 65:
		case 37:
		//Left
			keyLogger.keyStatus.left = true;
		break;
		case 68:
		case 39:
		//Rigth
			keyLogger.keyStatus.right = true;
		break;
		case 32:
		//Space
			keyLogger.keyStatus.fire = true;
		break;
		
		default:
			console.log("Key:" + key);
			return !false;
	}
	return !true;
	};
	this.keyUpListener = function(e){
		var key = e.keyCode ? e.keyCode : e.which;
		switch(key){
		
		case 87:
		case 38:
		//Up
			keyLogger.keyStatus.up = false;
		break;
		case 83:
		case 40:
		//Down
			keyLogger.keyStatus.down = false;
		break;
		case 65:
		case 37:
		//Left
			keyLogger.keyStatus.left = false;
		break;
		case 68:
		case 39:
		//Rigth
			keyLogger.keyStatus.right = false;
		break;
		case 32:
		//Space
			keyLogger.keyStatus.fire = false;
		break;
		default:
			console.log("Key:" + key);
			return !false;
	}
	return !true;
	};
	
	
	
	
}