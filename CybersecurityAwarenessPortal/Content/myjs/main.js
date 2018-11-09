
var sound = new Sounds();

var canvas,
    ctx,
    width,
    height,
    gameInterval,
    lastShootTime = 0;;

var BGI = new Image();
BGI.src = '/Content/myimages/background.png';


function testMain() {
    alert("ahhhhhhhh");
}
function Sounds() {
    this.backgroundSound = function () {
        var bgm = document.getElementById("backgroundMusic");
        bgm.play();
        setTimeout(function () { bgm.stop(); }, 1000);

    }

    this.actionSound = function () {
        var shotSound = document.getElementById("shotSoundTrack");
        shotSound.play();
    }
}
function startGame() {

    sound.backgroundSound();
    animateScript();


    gameInterval = setInterval(init, 10);
    var x = document.getElementById("gamepage");
    var question = document.getElementById("QuestionArea");
    var optionA = document.getElementById("OptionA");
    var optionB = document.getElementById("OptionB");
    var optionC = document.getElementById("OptionC");
    var optionD = document.getElementById("OptionD");
    var targetSprite = document.getElementById("targetSprite");
    //var targetSprite1 = document.getElementById("targetSprite1");
    //var targetSprite2 = document.getElementById("targetSprite2");

    if (x.style.display == "none") {
        x.style.display = "block";
        question.style.display = "none";
        optionA.style.display = "none";
        optionB.style.display = "none";
        optionC.style.display = "none";
        optionD.style.display = "none";
        targetSprite.style.display = "none";
        //targetSprite1.style.display = "none";
        //targetSprite2.style.display = "none";
    } else {
        x.style.display = "none";
        question.style.display = "block";
        optionA.style.display = "block";
        optionB.style.display = "block";
        optionC.style.display = "block";
        optionD.style.display = "block";
        targetSprite.style.display = "block";
        //targetSprite1.style.display = "block";
        //targetSprite2.style.display = "block";
    }
    questGen.randomNumberGenerator();
    questGen.Question();
}

function resetInterval() {
    gameInterval = setInterval(init, 10);
}

function stopGame() {
    clearInterval(gameInterval);
    //gameInterval = 0;
}

function init() {
    //	keyLogger.keyStatus.up;
    canvas = document.getElementById("canvas");
    width = canvas.width;
    height = canvas.height;
    ctx = canvas.getContext('2d');

    window.onkeydown = keyLogger.keyDownListener;
    window.onkeyup = keyLogger.keyUpListener;

    //Init player
    player.x = width / 2;
    player.y = height / 2;

    //Main game loop

    setInterval(function () {
        updateGame(0.01);
        renderGame();
    });

}



function updateGame(dt) {
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
    ctx.drawImage(BGI, 0, 0, canvas.width, canvas.height);
    ctx.fillRect(0, 0, width, height);
    //var test = parseInt(document.getElementById("buttonA").innerHTML) + 1;
    //document.getElementById("buttonA").innerHTML = test;
}

var tID; //we will use this variable to clear the setInterval()
function animateScript() {
    var position = 100; //start position for the image slicer
    const interval = 100; //100 ms of interval for the setInterval()
    tID = setInterval(() => {
        document.getElementById("image1").style.backgroundPosition = `-${position}px 0px`;
        document.getElementById("image2").style.backgroundPosition = `-${position}px 0px`;
        document.getElementById("image3").style.backgroundPosition = `-${position}px 0px`;
        document.getElementById("image4").style.backgroundPosition = `-${position}px 0px`;
        //we use the ES6 template literal to insert the variable "position"
        if (position < 600) {
            position = position + 100;
        }
        //we increment the position by 256 each time
        else {
            position = 100;
        }
        //reset the position to 256px, once position exceeds 1536px
    }, interval); //end of setInterval
} //end of animateScript()

function maintest() {
    alert("Main test");
}
