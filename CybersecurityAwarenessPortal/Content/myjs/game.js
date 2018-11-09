var Left_Key = 37;
var Up_Key = 38;
var Right_Key = 39;
var Down_Key = 40;
var Space_Key = 32;
var Hero_Movement = 10;

var lastLoopRun = 0;
var controller = new Object();




var sound = document.getElementById("laser");

var laserSound = new Audio("~/Content/mysound/LaserBlasts.wav");
var hoverSound = new Audio("~/mysound/Hover.wav");

function questionCounter() {
    var counter = parseInt(document.getElementById("QuestionCountLabel").innerText) + 1;
    document.getElementById("QuestionCountLabel").innerText = counter;
}

function correctAnswer() {
    var right = parseInt(document.getElementById("CorrectLabel").innerText) + 1;
    document.getElementById("CorrectLabel").innerText = right;
    questionCounter();
}
function incorrectAnswer() {
    alert("wrong");
    var wrong = parseInt(document.getElementById("IncorrectLabel").innerText) + 1;
    document.getElementById("IncorrectLabel").innerText = wrong;
    questionCounter();
}

function checkAnswer(userAnser, qAns) {
    if (userAnser == qAns) {
        correctAnswer();
        alert(userAnser);
    }
    else {
        incorrectAnswer();
        alert("The Right Answer is: \n" + qAns + "\n\nPlease, Press Enter or Click To Process");
    }
}

function shootResult(selected) {
    var qAns = document.getElementById("questionAnswer").innerText;

    var userAnser = "";

    alert(qAns);

    var userButtonClicked = document.getElementById("buttonA").innerText;
    //alert(userButtonClicked);

    if (selected == 1) {
        userAnser = document.getElementById("buttonA").innerText;

        checkAnswer(userAnser, qAns);

    }
    else if (selected == 2) {
        userAnser = document.getElementById("buttonB").innerText;
        checkAnswer(userAnser, qAns);
    }
    else if (selected == 3) {
        userAnser = document.getElementById("buttonC").innerText;
        checkAnswer(userAnser, qAns);
    }
    else if (selected == 4) {
        userAnser = document.getElementById("buttonD").innerText;
        checkAnswer(userAnser, qAns);
    }

}

function createSprite(element, x, y, w, h) {
    var result = new Object();
    result.element = element;
    result.x = x;
    result.y = y;
    result.w = w;
    result.h = h;
    return result;
}

function toggleKey(keyCode, isPressed) {
    if (keyCode == Left_Key) {
        controller.left = isPressed;
    }
    if (keyCode == Right_Key) {
        controller.right = isPressed;
    }
    if (keyCode == Up_Key) {
        controller.up = isPressed;
    }
    if (keyCode == Down_Key) {
        controller.down = isPressed;
    }
    if (keyCode == Space_Key) {
        laserSound.play();
        controller.space = isPressed;
    }
}

function ensureBounds(sprite) {
    if (sprite.x < 20) {
        sprite.x = 20;
    }
    if (sprite.y < 10) {
        sprite.y = 10;
    }
    if (sprite.x + sprite.w > 500) {
        sprite.x = 500 - sprite.w;
    }
    if (sprite.y + sprite.h > 520) {
        sprite.y = 520 - sprite.h;
    }
}

function setPosition(sprite) {
    var e = document.getElementById(sprite.element);
    e.style.left = sprite.x + 'px';
    e.style.top = sprite.y + 'px';
}
function handleControls() {
    if (controller.up) {
        //hoverSound.play();
        hero.y -= Hero_Movement;
    }
    if (controller.down) {
        //hoverSound.play();
        hero.y += Hero_Movement;
    }
    if (controller.left) {
        //hoverSound.play();
        hero.x -= Hero_Movement;
    }
    if (controller.right) {
        //hoverSound.play();
        hero.x += Hero_Movement;
    }
    if (controller.space && laser.x >= 1200) {
        //laserSound.play();
        laser.x = hero.x + 9;
        laser.y = hero.y + laser.h;
    }
    ensureBounds(hero);
}
function showSprite() {
    setPosition(hero);
    setPosition(laser);
    setPosition(optA);
    setPosition(optB);
    setPosition(optC);
    setPosition(optD);

    setPosition(optATarget);
    setPosition(optBTarget);
    setPosition(optCTarget);
    setPosition(optDTarget);
}

function updatePosition() {

    laser.x += 20;
}

function loop() {
    if (new Date().getTime() - lastLoopRun > 40) {
        updatePosition();
        handleControls();
        showSprite();

        lastLoopRun = new Date().getTime();
    }
    setTimeout('loop();', 2);
    if (laser.x > 1200) {
        laser.x = 1199;
        laser.y = 0;
    } else if (laser.x > 720 && laser.y > 20 && laser.y < 140) {
        if (laser.x > 680 && laser.y > 70 && laser.y < 90) {
            alert("A, Point 2");
            laser.x = 1199;
            laser.y = 0;
            shootResult(1);
        } else {

            laser.x = 1199;
            laser.y = 0;
        }

    } else if (laser.x > 720 && laser.y > 150 && laser.y < 270) {
        if (laser.x > 680 && laser.y > 200 && laser.y < 220) {
            alert("B, Point 2");
            laser.x = 1199;
            laser.y = 0;
            shootResult(2);
        } else {
            alert("B, Point 1");
            laser.x = 1199;
            laser.y = 0;
            shootResult(2);
        }

    } else if (laser.x > 720 && laser.y > 260 && laser.y < 400) {
        if (laser.x > 680 && laser.y > 330 && laser.y < 350) {
            alert("C, Point 2");
            laser.x = 1199;
            laser.y = 0;
            shootResult(3);
        } else {
            alert("C, Point 1");
            laser.x = 1199;
            laser.y = 0;

            shootResult(3);
        }

    } else if (laser.x > 720 && laser.y > 410 && laser.y < 530) {
        if (laser.x > 680 && laser.y > 460 && laser.y < 410) {
            alert("D, Point 2");
            laser.x = 1199;
            laser.y = 0;
            shootResult(4);
        } else {

            laser.x = 1199;
            laser.y = 0;
            alert("D, Point 1");
            shootResult(4);
        }

    }
}

document.onkeydown = function (evt) {
    toggleKey(evt.keyCode, true);
};

document.onkeyup = function (evt) {
    toggleKey(evt.keyCode, false);
};

var hero = createSprite('hero', 20, 265, 0, 0);
var laser = createSprite('laser', 0, -120, 0, 0);

var optA = createSprite('OptionA', 700, 20, 0, 0);
var optB = createSprite('OptionB', 700, 150, 0, 0);
var optC = createSprite('OptionC', 700, 280, 0, 0);
var optD = createSprite('OptionD', 700, 410, 0, 0);

var optATarget = createSprite('OptionATarget', 680, 70, 0, 0);
var optBTarget = createSprite('OptionBTarget', 680, 200, 0, 0);
var optCTarget = createSprite('OptionCTarget', 680, 330, 0, 0);
var optDTarget = createSprite('OptionDTarget', 680, 460, 0, 0);


loop();