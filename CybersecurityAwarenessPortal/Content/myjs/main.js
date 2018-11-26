var sound = new Sounds();

var canvas,
	ctx,
	width,
	height,
    gameInterval,
    lastShootTime = 0,
    animationTimer; //we will use this variable to clear the setInterval()

var BGI = new Image();
	BGI.src = '/Content/myimages/background.png';

function Sounds(){
	this.backgroundSound = function (){
        var bgm = document.getElementById("backgroundMusic");
        bgm.loop = true;
        bgm.play();
        //setTimeout(function () { bgm.stop(); }, 1000);
	}
	this.actionSound = function (){
		var shotSound = document.getElementById("shotSoundTrack");
		shotSound.play();
	}
}

function startGame() {
    questGen.counter = 0;
    var optionClickedSound = document.getElementById("optionClicked");
    optionClickedSound.play();
     sound.backgroundSound();
    //alert("t4ar");
   // animateScript();
    gameInterval = setInterval(init, 10);
    
    var gamepage = document.getElementById("gameBackGround");
    var question = document.getElementById("QuestionArea");
    var optionA = document.getElementById("OptionA");
    var optionB = document.getElementById("OptionB");
    var optionC = document.getElementById("OptionC");
    var optionD = document.getElementById("OptionD");
    var targetSprite = document.getElementById("targetSprite");
    
    if (gamepage.style.display == "none") {
        gamepage.style.display = "block";
        question.style.display = "none";
        optionA.style.display = "none";
        optionB.style.display = "none";
        optionC.style.display = "none";
        optionD.style.display = "none";
        targetSprite.style.display = "none";
     } else {
        gamepage.style.display = "none";
        question.style.display = "block";
        optionA.style.display = "block";
        optionB.style.display = "block";
        optionC.style.display = "block";
        optionD.style.display = "block";
        targetSprite.style.display = "block";
    } 
    //  alert("Start Test");
    //questGen.testQuest();
    questGen.randomNumberGenerator();
    
    questGen.Question();
}

function resetInterval() {
    gameInterval = setInterval(init, 10);    
}

function stopGame() {
    clearInterval(gameInterval);
}

function init(){
    //	keyLogger.keyStatus.up;
	canvas = document.getElementById("canvas");
	width = canvas.width;
	height = canvas.height;
	ctx = canvas.getContext('2d');

	window.onkeydown = keyLogger.keyDownListener;
	window.onkeyup = keyLogger.keyUpListener;
	
	//Init player
	player.x = width/2;
	player.y = height/2;
	
	//Main game loop
	
	setInterval(function(){
		updateGame(0.01);
		renderGame();	
	});
}

function updateGame(dt){
	bullets.update(dt);
	targets.update(dt);
	player.update(dt);
}

function renderGame() {
    renderBackground();
    player.render(ctx);
    bullets.render(ctx);
	targets.render(ctx);
}

function renderBackground() {
	ctx.fillStyle = "rgba(255,255,255,0.1)";
	ctx.drawImage(BGI,0,0,canvas.width,canvas.height);
	ctx.fillRect(0,0,width,height);
}

function maintest() {
    alert("Main test");
}
