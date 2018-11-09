var bullets = new Bullets();

function Bullets() {
    this.objects = [];
    this.maxID = 0;

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
                    questGen.shootResult(1);
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;
                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }
                    //stopGame();
                    //resetInterval();
                }
            }
            var OB = document.getElementById("OptionB");
            if (OB.style.display == "block") {

                if (obj.x < 430 && obj.y > 601 && obj.x > 30 && obj.y < 660) {
                    //alert("Option B");
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
                    //questGen.test();
                    questGen.shootResult(3)
                    keyLogger.keyStatus.fire = false;
                    keyLogger.keyStatus.up = false;
                    keyLogger.keyStatus.down = false;
                    for (var a = 0; a <= this.maxID; a++) {
                        delete this.objects[a];
                    }
                    questGen.shootResult(3);

                }
            }
            var OD = document.getElementById("OptionD");
            if (OD.style.display == "block") {

                if (obj.x > 850 && obj.y > 601 && obj.x < 1250 && obj.y < 660) {
                    //alert("Option D");
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
        ctx.fillStyle = "#000000";
        for (var i = 0; i < this.maxID; i++) {
            if (this.objects[i] == undefined) continue;

            var obj = this.objects[i];
            ctx.beginPath();
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
