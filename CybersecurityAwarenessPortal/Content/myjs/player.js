var player = new Player();

var playerImageMain = new Image();
playerImageMain.src = '/Content/myimages/player.png';
/*
var playerImageA = new Image();
playerImageA.src = '/Content/myimages/char1.png';

var playerImageB = new Image();
playerImageB.src = '/Content/myimages/char2.png';

var playerImageC = new Image();
playerImageC.src = '/Content/myimages/char3.png';

var playerImageD = new Image();
playerImageD.src = '/Content/myimages/char4.png';

var playerImageMainPointer = new Image();
playerImageD.src = '/Content/myimages/spikes.png';

*/
function Player() {
    this.x = 0;
    this.y = 0;
    this.vx = 0;
    this.vy = 0;
    this.v = 0;
    this.angle = 0;
    this.lastShootTime = 0;
    this.animationTime = 0;

    this.shooterPointerColor = 0;
    this.playerChoiceChar = 3;
    this.shooterPointerColorRandomized = 0;

    var position = 256;

    var test = "";

    this.shootPointer = function (nuzzleNum) {
        this.shooterPointerColor = nuzzleNum;
    }

    this.playerChoice = function (playerNum) {
        this.playerChoiceChar = playerNum;
        if (this.playerChoiceChar == 0) { playerImageMain.src = '/Content/myimages/player1.png'; }
        if (this.playerChoiceChar == 1) { playerImageMain.src = '/Content/myimages/player2.png'; }
        if (this.playerChoiceChar == 2) { playerImageMain.src = '/Content/myimages/player3.png'; }
        if (this.playerChoiceChar == 3) { playerImageMain.src = '/Content/myimages/player4.png'; }
        if (this.playerChoiceChar == 4) { playerImageMain.src = '/Content/myimages/player5.png'; }
    }
    this.stats = { maxV: 100, dAngle: 0.03, acc: 10, shootDelayMs: 100 };

    this.update = function (dt) {
        if (keyLogger.keyStatus.left) {
            this.angle -= this.stats.dAngle;
            if (this.angle < 3 || this.angle > 6)
                this.angle += 2 * Math.PI;
            test = this.angle;
            console.log(this.angle);
        }
        if (keyLogger.keyStatus.right) {
            this.angle += this.stats.dAngle;
            if (this.angle > 2 * Math.PI)
                this.angle -= 2 * Math.PI;
            test = this.angle;
            console.log(this.angle);
        }


        if (!(keyLogger.keyStatus.up || keyLogger.keyStatus.down))
            this.v *= 0.99;
        this.vx = this.v * Math.cos(this.angle);
        this.vy = this.v * Math.sin(this.angle);

        this.x += this.vx * dt;
        this.y += this.vy * dt;

        var time = utils.getTime();
        if (keyLogger.keyStatus.fire && time - this.lastShootTime >= this.stats.shootDelayMs) {
            var shoooting = document.getElementById("optionShooting");
            shoooting.play();


            //sound.backgroundSound();
            bullets.push({
                x: this.x,
                y: this.y,
                angle: this.angle,
                v: 250
            });
            this.lastShootTime = time;
        }
		/*
		tID = setInterval(() => {
               document.getElementById("image").style.backgroundPosition =
                   `-${position}px 0px`;
               //we use the ES6 template literal to insert the variable "position"
               if (position < 1536) { position = position + 256; }
               //we increment the position by 256 each time	
               else { position = 256; }
               //reset the position to 256px, once position exceeds 1536px
           }
               , interval); //end of setInterval
		
		if((time - this.animationTime) >= 100){
			document.getElementById("image").style.backgroundPosition = `-${position}px 0px`;
               //we use the ES6 template literal to insert the variable "position"
               if (position < 1536) { position = position + 256; }
               //we increment the position by 256 each time
               else { position = 256; }
			});
			this.animationTime = time;
		}*/

    };

    this.render = function (ctx) {

        if (this.shooterPointerColor == 0) {
            ctx.strokeStyle = "#000000";
        }

        if (this.shooterPointerColor == 1) {
            ctx.strokeStyle = "#FF0000";
        }
        if (this.shooterPointerColor == 2) {
            ctx.strokeStyle = "#00FF00";
        }
        if (this.shooterPointerColor == 3) {
            ctx.strokeStyle = "#0000FF";
        }
        if (this.shooterPointerColor == 4) {
            this.shooterPointerColorRandomized = Math.floor(Math.random() * 7);
            if (this.shooterPointerColorRandomized == 0) { ctx.strokeStyle = "#000000"; }
            if (this.shooterPointerColorRandomized == 1) { ctx.strokeStyle = "#FFFFFF"; }
            if (this.shooterPointerColorRandomized == 2) { ctx.strokeStyle = "#FF0000"; }
            if (this.shooterPointerColorRandomized == 3) { ctx.strokeStyle = "#00FF00"; }
            if (this.shooterPointerColorRandomized == 4) { ctx.strokeStyle = "#0000FF"; }
            if (this.shooterPointerColorRandomized == 5) { ctx.strokeStyle = "#FFFF00"; }
            if (this.shooterPointerColorRandomized == 6) { ctx.strokeStyle = "#FF00FF"; }
            if (this.shooterPointerColorRandomized == 7) { ctx.strokeStyle = "#00FFFF"; }
        }


        ctx.beginPath();
        ctx.lineWidth = 10;
        ctx.moveTo(this.x, this.y);
        var pointerLength = 40;
        //ctx.drawImage(playerImageMain, this.x- 15 + pointerLength  * Math.cos(this.angle), this.y- 15 + pointerLength * Math.sin(this.angle), 30, 30);
        ctx.lineTo(
            this.x + pointerLength * Math.cos(this.angle),
            this.y + pointerLength * Math.sin(this.angle)
        );

        ctx.stroke();

        ctx.drawImage(playerImageMain, this.x - 25, this.y - 25, 50, 50);

    };

}