var bullets = new Bullets();

var bulletImage = new Image();
bulletImage.src = '/Content/myimages/player.png';

function Bullets() {
    this.objects = [];
    this.maxID = 0;

    this.bulletChoice = 0;
    this.bulletChoiceRandomized = 0;

    this.bulletPicked = function (bulletNumber) {
        this.bulletChoice = bulletNumber;
        
        /*
        if (this.bulletChoice == 0) {
            alert("black");
            //document.getElementById("ammoSelected").innerHTML == "Black";
            bulletImage.src = '/Content/myimages/bullet1.png';
        }
        if (this.bulletChoice == 1) {
            //document.getElementById("ammoSelected").innerHTML == "Red";
            bulletImage.src = '/Content/myimages/bullet2.png';
        }
        if (this.bulletChoice == 2) {
            //document.getElementById("ammoSelected").innerHTML == "Green";
            bulletImage.src = '/Content/myimages/bullet3.png';
        }
        if (this.bulletChoice == 3) {
            //document.getElementById("ammoSelected").innerHTML == "Blue";
            bulletImage.src = '/Content/myimages/bullet4.png';
        }
        if (this.bulletChoice == 4) {
            //document.getElementById("ammoSelected").innerHTML == "Frenzy Color";
            bulletImage.src = '/Content/myimages/bullet5.png';
        }*/
    }

    this.init = function (bullet) {
        bullet.vx = bullet.v * Math.cos(bullet.angle);
        bullet.vy = bullet.v * Math.sin(bullet.angle);
    }

    this.push = function (bullet) {

        this.init(bullet);

        var id = -1;
        //Search empty space
        while (this.objects[++id] != undefined);
        this.objects[id] = bullet;
        if (id > this.maxID) this.maxID = id;
    };

    this.update = function (dt) {
        var optionshot = document.getElementById("optionShot");

        for (var i = 0; i <= this.maxID; i++) {
            if (this.objects[i] == undefined) continue;

            var obj = this.objects[i];

            obj.x += obj.vx * dt;
            obj.y += obj.vy * dt;
            //Detect if on screen
            if (obj.x < 0 || obj.y < 0 || obj.x > width || obj.y > height || obj.remove) {
                delete this.objects[i];
            }
            var OA = document.getElementById("OptionA");
            if (OA.style.display == "block") {

                if (obj.x < 430 && obj.y > 160 && obj.x > 30 && obj.y < 223) {
                    //player.enablePlayer(false);
                    //	keyLogger.keyStatus.up;
                    //alert("Option A");
                    var optionshot = document.getElementById("optionShot");
                    optionshot.play();
                    questGen.shootResult(1);
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;

                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }
                }
            }
            var OB = document.getElementById("OptionB");
            if (OB.style.display == "block") {

                if (obj.x < 430 && obj.y > 601 && obj.x > 30 && obj.y < 660) {
                    //alert("Option B");
                    var optionshot = document.getElementById("optionShot");
                    optionshot.play();
                    questGen.shootResult(2);
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;

                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }
                }
            }
            var OC = document.getElementById("OptionC");
            if (OC.style.display == "block") {

                if (obj.x > 850 && obj.y > 156 && obj.x < 1250 && obj.y < 225) {
                    //alert("Option C");
                    var optionshot = document.getElementById("optionShot");
                    optionshot.play();
                    questGen.shootResult(3);
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;

                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }
                }
            }
            var OD = document.getElementById("OptionD");
            if (OD.style.display == "block") {

                if (obj.x > 850 && obj.y > 601 && obj.x < 1250 && obj.y < 660) {
                    //alert("Option D");
                    var optionshot = document.getElementById("optionShot");
                    optionshot.play();
                    questGen.shootResult(4);
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;

                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }

                }
            }

        }
    }

    this.render = function (ctx) {
        for (var i = 0; i < this.maxID; i++) {
            if (this.objects[i] == undefined) continue;

            var obj = this.objects[i];

            ctx.beginPath();
            if (this.bulletChoice == 0) {
                bulletImage.src = '/Content/myimages/bullet1.png';
                document.getElementById("ammoSelected").innerHTML = "Earth";
                //ctx.drawImage(bulletImage, obj.x - 15, obj.y - 15, 30, 30);
                //ctx.fillStyle = "#000000";

            }
            if (this.bulletChoice == 1) {
                bulletImage.src = '/Content/myimages/bullet2.png';
                document.getElementById("ammoSelected").innerHTML = "Earth";
                //ctx.drawImage(bulletImage, obj.x - 15, obj.y - 15, 30, 30);
                //ctx.fillStyle = "#FF0000";
            }
            if (this.bulletChoice == 2) {
                bulletImage.src = '/Content/myimages/bullet3.png';
                document.getElementById("ammoSelected").innerHTML = "Moon";
                //ctx.drawImage(bulletImage, obj.x - 15, obj.y - 15, 30, 30);
                //ctx.fillStyle = "#00FF00";
            }
            if (this.bulletChoice == 3) {
                bulletImage.src = '/Content/myimages/bullet4.png';
                document.getElementById("ammoSelected").innerHTML = "Venus";
                //ctx.drawImage(bulletImage, obj.x - 15, obj.y - 15, 30, 30);
                //ctx.fillStyle = "#0000FF";
            }
            if (this.bulletChoice == 4) {
                bulletImage.src = '/Content/myimages/bullet5.png';
                document.getElementById("ammoSelected").innerHTML = "Jupiter";
                //ctx.drawImage(bulletImage, obj.x - 15, obj.y - 15, 30, 30);
                /*
                    bulletChoiceRandomized = Math.floor(Math.random() * 7);
                    if(bulletChoiceRandomized == 0){ctx.fillStyle = "#000000";}
                    if(bulletChoiceRandomized == 1){ctx.fillStyle = "#FFFFFF";}
                    if(bulletChoiceRandomized == 2){ctx.fillStyle = "#FF0000";}
                    if(bulletChoiceRandomized == 3){ctx.fillStyle = "#00FF00";}
                    if(bulletChoiceRandomized == 4){ctx.fillStyle = "#0000FF";}
                    if(bulletChoiceRandomized == 5){ctx.fillStyle = "#FFFF00";}
                    if(bulletChoiceRandomized == 6){ctx.fillStyle = "#FF00FF";}
                    if(bulletChoiceRandomized == 7){ctx.fillStyle = "#00FFFF";}
             */   
            }
            ctx.drawImage(bulletImage, obj.x - 13, obj.y - 13, 26, 26);
            ctx.arc(obj.x, obj.y, 10, 0, 6.28);
            ctx.fill();
        }
    };

    this.getSize = function () {
        var size = 0;
        for (var i = 0; i <= this.maxID; i++) {
            if (this.objects[i] == undefined) continue;
            size++;
        }
        return size;
    };

    this.getMinInfo = function (o) {
        var dist = 99999;
        var obj;
        for (var i = 0; i <= this.maxID; i++) {
            if (this.objects[i] == undefined) continue;
            var d = Math.sqrt(
                (o.x - this.objects[i].x) * (o.x - this.objects[i].x) +
                (o.y - this.objects[i].y) * (o.y - this.objects[i].y)
            );
            if (d < dist) {
                dist = d;
                obj = this.objects[i];
            }
        }
        return { dist: dist, object: obj };
    };

}
