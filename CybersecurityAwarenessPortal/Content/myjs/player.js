var player = new Player();

var playerImageMain = new Image();
playerImageMain.src = '/Content/myimages/player.png';

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

function Player() {
    this.x = 0;
    this.y = 0;
    this.vx = 0;
    this.vy = 0;
    this.v = 0;
    this.angle = 0;
    this.lastShootTime = 0;

    var test = "";

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
            sound.actionSound();
            bullets.push({
                x: this.x,
                y: this.y,
                angle: this.angle,
                v: 250
            });
            this.lastShootTime = time;
        }

    };

    this.render = function (ctx) {
        ctx.strokeStyle = "#FF0000";

        ctx.beginPath();
        ctx.lineWidth = 7;
        ctx.moveTo(this.x, this.y);
        var pointerLength = 30;
        ctx.drawImage(playerImageMainPointer, this.x - 15 + pointerLength * Math.cos(this.angle), this.y - 15 + pointerLength * Math.sin(this.angle), 30, 30);
        ctx.lineTo(
            this.x + pointerLength * Math.cos(this.angle),
            this.y + pointerLength * Math.sin(this.angle)
        );
        ctx.stroke();

		/*
		ctx.drawImage(playerImageA, 185, 30, 100, 100);
		ctx.drawImage(playerImageB, 185, 500, 100, 100);
		ctx.drawImage(playerImageC, 1002, 30, 100, 100);
		ctx.drawImage(playerImageD, 1002, 500, 100, 100);
		*/
        ctx.drawImage(playerImageMain, this.x - 15, this.y - 15, 30, 30);

    };

}