var targets = new Targets();

/*
	Target{
		x,
		y,
		v,
		angle,
		color,
		size,
		remove,
		hitAnimClock
	}
	
*/
function Targets() {

    this.objects = [];
    this.maxID = 0;

    this.init = function (target) {
        target.vx = target.v * Math.cos(target.angle);
        target.vy = target.v * Math.sin(target.angle);
        target.hitAnimClock = -1;
        target.scale = 1;
        target.alpfa = 0;
        target.nextAlpfa = 1;
    }

    this.push = function (target) {
        this.init(target);
        var i = -1;
        while (this.objects[++i] != undefined);
        this.objects[i] = target;
        if (this.maxID < i) this.maxID = i;
    };
    this.getSize = function () {
        var size = 0;
        for (var i = 0; i < this.maxID; i++) {
            if (this.objects[i] == undefined) continue;
            size++;
        }
        return size;
    };

    this.update = function (dt) {
        for (var i = 0; i < this.maxID; i++) {
            if (this.objects[i] == undefined) continue;
            var obj = this.objects[i];

            obj.x += obj.vx * dt;
            obj.y += obj.vy * dt;

            if (obj.alpfa != obj.nextAlpfa) {
                obj.alpfa += (obj.nextAlpfa - obj.alpfa) / 10
            }

            if (obj.alpfa > 0.1) {
                var info = bullets.getMinInfo(obj);

                if (info.dist <= obj.size * obj.scale) {
                    info.object.remove = true;
                    if (obj.hitAnimClock == -1)
                        obj.hitAnimClock = 0;
                }
            }
            if (obj.hitAnimClock != -1) {
                obj.hitAnimClock += dt;
                if (obj.hitAnimClock >= 1) {
                    delete this.objects[i];
                    continue;
                }
            }

            //Detect if on screen
            if (
                obj.x < 0 || obj.y < 0 ||
                obj.x > width || obj.y > height
            )
                delete this.objects[i];
        }

        if (this.getSize() < 5) {
            this.push({
                x: Math.random() * width,
                y: Math.random() * height,
                v: 5,
                angle: Math.random() * 2 * Math.PI,
                size: 25,
                color: {
                    r: Math.random(),
                    g: Math.random(),
                    b: Math.random(),
                }
            });
        }


    };
    this.render = function (ctx) {
		/*for(var i = 0;i < this.maxID;i++){
			if(this.objects[i] == undefined) continue;
			
			var obj = this. objects[i];
			
			obj.scale = 1;
			if(obj.hitAnimClock != -1){
				obj.alpfa = 1 - obj.hitAnimClock*1.5;
				if(obj.alpfa < 0)obj.alpfa = 0;
				obj.scale = 1 + 2 * obj.hitAnimClock;
				obj.nextAlpfa = obj.alpfa;
			}
			ctx.fillStyle = utils.getARGBString(
				obj.alpfa,
				obj.color.r,
				obj.color.g,
				obj.color.b
			);
			ctx.globalAlpha=obj.alpfa;
			ctx.beginPath();
			ctx.arc(obj.x,obj.y,obj.size * obj.scale,0,6.28);
			ctx.fill();
			ctx.globalAlpha=1;
		}
		
		ctx.fillStyle = "#FFFF00";
		ctx.fillRect(30, 129, 400, 97);
		
		ctx.fillStyle = "ffff00";
		ctx.fillRect(30, 600, 400, 97);
		
		ctx.fillStyle = "ff00ff";
		ctx.fillRect(850, 129, 400, 97);
		
		ctx.fillStyle = "00ff00";
		ctx.fillRect(850, 600, 400, 97);
		
		ctx.fillStyle = "#00ff00";
		ctx.fillRect(385, 242, 506, 75);
		*/
    };





}