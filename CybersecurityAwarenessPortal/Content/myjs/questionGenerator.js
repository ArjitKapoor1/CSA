var questGen = new questionGenerator();

function titi() {
    alert("Quest Test");
}

function questionGenerator() {
    this.exists = [],
    this.randomNumber,
    this.max = 10,
    this.counter = 1,
    this.randNum = [],
        this.questionCount;

    this.gameStart = 0;
    this.gameFinish = 0;
    this.questionTimeStart = 0;
    this.questionTimeFinish = 0;
    this.questionTimeResult = 0.0;

    this.point = 0;
    this.bonus = 0;
    this.bonusUsed = 0;
    this.markWithBonus = 0;

    
    this.questionCounter = function () {
        var counter = parseInt(document.getElementById("QuestionCountLabel").innerText) + 1;
        document.getElementById("QuestionCountLabel").innerText = counter;
    }

    this.correctAnswer = function () {
        var right = parseInt(document.getElementById("CorrectLabel").innerText) + 1;

        

        var adminMark = parseInt(document.getElementById("adminPassMarkLabel").innerHTML);

        //alert(adminMark);

        var correctResult = document.getElementById("stats");

        var userFinalMark = document.getElementById("userCorrectLabel");
        var userFinalPoint = document.getElementById("pointEndGamePageLabel");
        var calculate = 0;
        
        var previousAttempt = parseInt(document.getElementById("attemptLabel").innerText) + 1;
        var currentAttempt = document.getElementById("currentAttemptLabel");


        var enq = document.getElementById("gameEnqueryBackGround");

        var question = document.getElementById("QuestionArea");
        var optionA = document.getElementById("OptionA");
        var optionB = document.getElementById("OptionB");
        var optionC = document.getElementById("OptionC");
        var optionD = document.getElementById("OptionD");
        var targetSprite = document.getElementById("targetSprite");


        //alert(previousAttempt);
        document.getElementById("CorrectLabel").innerHTML = right;

        calculate = (right / 10) * 100;

        
    
        if (calculate >= adminMark) {
            var pass = document.getElementById("passfail");
            pass.innerHTML = "PASSED";
            pass.style.color = "yellow";
            userFinalMark.value = "" + calculate;
        } else {

            if (calculate == (adminMark - 10)) {
                //alert("70 Mark ");
                if (this.bonus >= 10) {
                    //alert("10++ Bonus");
                    calculate += 10;
                    this.bonusUsed = 10;
                    //this.bonus -= 10;
                    //alert("70 Mark + " + calculate);
                    if (calculate >= adminMark) {
                        var pass = document.getElementById("passfail");
                        pass.innerHTML = "PASSED (Bonus++)";
                        pass.style.color = "orange";
                        userFinalMark.value = "" + calculate;
                    }
                    else {
                        var fail = document.getElementById("passfail");
                        calculate += this.bonus;
                        this.bonusUsed = this.bonus;
                        fail.innerHTML = "FAILED";
                        fail.style.color = "red";
                        userFinalMark.value = "" + calculate;
                    }
                }
                else {
                    var fail = document.getElementById("passfail");
                    calculate += this.bonus;
                    this.bonusUsed = this.bonus;
                    fail.innerHTML = "FAILED (Bonus++)";
                    fail.style.color = "red";
                    userFinalMark.value = "" + calculate;
                }

            }
            else if (calculate == (adminMark - 20)) {
                //alert("70 Mark");
                if (this.bonus >= 20) {
                    calculate = calculate + 20;
                    this.bonusUsed = 20;
                    //this.bonus -= 20;
                    if (calculate >= adminMark) {
                        var pass = document.getElementById("passfail");
                        pass.innerHTML = "PASSED (Bonus++)";
                        pass.style.color = "orange";
                        userFinalMark.value = "" + calculate;
                    }
                    else {
                        var fail = document.getElementById("passfail");
                        calculate += this.bonus;
                        this.bonusUsed = this.bonus;
                        fail.innerHTML = "FAILED (Bonus++)";
                        fail.style.color = "red";
                        userFinalMark.value = "" + calculate;
                    }
                }
                else {
                    var fail = document.getElementById("passfail");
                    calculate += this.bonus;
                    this.bonusUsed = this.bonus;
                    fail.innerHTML = "FAILED (Bonus++)";
                    fail.style.color = "red";
                    userFinalMark.value = "" + calculate;
                }
            }

            else if (calculate == (adminMark - 30)) {
                ///alert("70 Mark");
                if (this.bonus >= 30) {
                    calculate = calculate + 30;
                    this.bonusUsed = 30;
                    //this.bonus -= 20;
                    if (calculate >= adminMark) {
                        var pass = document.getElementById("passfail");
                        pass.innerHTML = "PASSED (Bonus++)";
                        pass.style.color = "orange";
                        userFinalMark.value = "" + calculate;
                    }
                    else {
                        var fail = document.getElementById("passfail");
                        calculate += this.bonus;
                        this.bonusUsed = this.bonus;
                        fail.innerHTML = "FAILED (Bonus++)";
                        fail.style.color = "red";
                        userFinalMark.value = "" + calculate;
                    }
                }
                else {
                    var fail = document.getElementById("passfail");
                    calculate += this.bonus;
                    this.bonusUsed = this.bonus;
                    fail.innerHTML = "FAILED (Bonus++)";
                    fail.style.color = "red";
                    userFinalMark.value = "" + calculate;
                }
            }
            else {
                calculate += this.bonus;
                this.bonusUsed = this.bonus;
                var fail = document.getElementById("passfail");
                fail.innerHTML = "FAILED (Bonus++)";
                fail.style.color = "red";
                userFinalMark.value = "" + calculate;
            }

        }

        correctResult.innerHTML = "Correct!!"
        correctResult.style.color = "yellow";


        document.getElementById("bonusEarnedEndGamePageLabel").innerHTML = this.bonus;
        document.getElementById("bonusUsedEndGamePageLabel").innerHTML = this.bonusUsed;


        document.getElementById("correctEnqueryLabel").innerHTML = right;
        
        


        currentAttempt.value = "" + previousAttempt;
        userFinalPoint.value = "" + this.point;
        

        
        

        document.getElementById("enqueryQuestion").innerHTML = document.getElementById("questionLabel").innerHTML;
        document.getElementById("EnqueryOption").innerHTML = "Congratulation, You Answered Correctly.";

        questGen.questionCounter();

        question.style.display = "none";
        optionA.style.display = "none";
        optionB.style.display = "none";
        optionC.style.display = "none";
        optionD.style.display = "none";
        targetSprite.style.display = "none";

        enq.style.display = "block";
    }
    this.incorrectAnswer = function () {
        var qAns = document.getElementById("answerLabel").innerHTML;

        var correctResult = document.getElementById("stats");

        var wrong = parseInt(document.getElementById("IncorrectLabel").innerText) + 1;


        var question = document.getElementById("QuestionArea");
        var optionA = document.getElementById("OptionA");
        var optionB = document.getElementById("OptionB");
        var optionC = document.getElementById("OptionC");
        var optionD = document.getElementById("OptionD");
        var targetSprite = document.getElementById("targetSprite");

        var enq = document.getElementById("gameEnqueryBackGround");


        qAns = qAns.substr(1, 1);
        //alert("=" + ans + "=");
        //document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonA").innerHTML;

        if (qAns == "a") {
            document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonA").innerHTML;
        }

        if (qAns == "b") {
            document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonB").innerHTML;

        }

        if (qAns == "c") {
            document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonC").innerHTML;
        }

        if (qAns == "d") {
            document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonD").innerHTML;
        }

        
        correctResult.innerHTML = "Incorrect!!"
        correctResult.style.color = "red";
        correctResult.style.fontSize = "25px";

        document.getElementById("enqueryQuestion").innerHTML = document.getElementById("questionLabel").innerHTML;

        document.getElementById("incorrectEnqueryLabel").innerHTML = wrong;

        
        document.getElementById("IncorrectLabel").innerHTML = wrong;
        questGen.questionCounter();


        

        question.style.display = "none";
        optionA.style.display = "none";
        optionB.style.display = "none";
        optionC.style.display = "none";
        optionD.style.display = "none";
        targetSprite.style.display = "none";


        enq.style.display = "block";

    }

    this.checkAnswer = function (userAnser, qAns) {
        if (userAnser == qAns) {
			//alert("check Correct Answer");
            this.point += 1;
            this.bonus += 3;
            if (this.questionTimeResult <= 10.0) {
                this.point += 2;
                document.getElementById("pointEnqueryLabel").innerHTML = this.point;
                document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
                document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;

            } else {
                this.point += 1;
                document.getElementById("pointEnqueryLabel").innerHTML = this.point;
                document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
                document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;
            }
            questGen.correctAnswer();
            //alert(userAnser);
        
        }
        else {
            document.getElementById("pointEnqueryLabel").innerHTML = this.point;
            document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
            document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;

			//alert("check Incorrect Answer");
            questGen.incorrectAnswer(qAns);
            //alert("The Right Answer is: \n" + qAns + "\n\nPlease, Press Enter or Click To Process");

        }
        
    }

    this.testQuest = function () {
        alert("Quest");
    }

    this.shootResult = function (selected) {
        this.questionTimeFinish = utils.getTime();
        this.questionTimeResult = (this.questionTimeFinish - this.questionTimeStart) / 1000;

        var qAns = document.getElementById("answerLabel").innerHTML;
        
	    var userAnser = "";

        qAns = qAns.substr(1, 1);

        
        //alert("The Answer is: " + qAns+ "-");

        var userButtonClicked = document.getElementById("buttonA").innerText;
        //alert(userButtonClicked);

        if (selected == 1) {
            //userAnser = document.getElementById("buttonA").innerText;
			//alert("Option A Selected");
			userAnser = "a";
            
            questGen.checkAnswer(userAnser, qAns);

        }
        else if (selected == 2) {
            //userAnser = document.getElementById("buttonB").innerText;
			//alert("Option B Selected");
            userAnser = "b";
            questGen.checkAnswer(userAnser, qAns);
        }
        else if (selected == 3) {
            //userAnser = document.getElementById("buttonC").innerText;
			//alert("Option C Selected");
            userAnser = "c";
            questGen.checkAnswer(userAnser, qAns);
        }
        else if (selected == 4) {
            //userAnser = document.getElementById("buttonD").innerText;
			//alert("Option D Selected");
            userAnser = "d";
            questGen.checkAnswer(userAnser, qAns);
        }

    }



    this.clickCheckAnswer = function (userAnswer, qAnsclicked) {
        if (userAnswer == qAnsclicked) {
            //alert("check Correct Answer");
            this.point += 1;
            if (this.questionTimeResult <= 10.0) {
                this.point += 2;
                document.getElementById("pointEnqueryLabel").innerHTML = this.point;
                document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
                document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;

            } else {
                this.point += 1;
                document.getElementById("pointEnqueryLabel").innerHTML = this.point;
                document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
                document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;
            }
            questGen.correctAnswer();
            //alert(userAnser);

        }
        else {
            document.getElementById("pointEnqueryLabel").innerHTML = this.point;
            document.getElementById("elapseLabel").innerHTML = this.questionTimeResult;
            document.getElementById("bonusEnqueryLabel").innerHTML = this.bonus;

            //alert("check Incorrect Answer");
            questGen.incorrectAnswer(qAnsclicked);
            //alert("The Right Answer is: \n" + qAns + "\n\nPlease, Press Enter or Click To Process");

        }

    }

    this.clickedResult = function (selected) {
        this.questionTimeFinish = utils.getTime();
        this.questionTimeResult = (this.questionTimeFinish - this.questionTimeStart) / 1000;

        var optionClickedSound = document.getElementById("optionClicked");
        optionClickedSound.play();

        var qAnsclicked = document.getElementById("answerLabel").innerHTML;

        qAnsclicked = qAnsclicked.substr(1, 1);
        var userAnswer = "";

        //alert("The Answer is: " + qAns+ "-");

        //var userButtonClicked = document.getElementById("buttonA").innerText;
        //alert(userButtonClicked);

        if (selected == 1) {
            //userAnser = document.getElementById("buttonA").innerText;
            //alert("Option A Selected");
            userAnswer = "a";
            questGen.clickCheckAnswer(userAnswer, qAnsclicked);
        }
        else if (selected == 2) {
            //userAnser = document.getElementById("buttonB").innerText;
            //alert("Option B Selected");
            userAnswer = "b";
            questGen.clickCheckAnswer(userAnswer, qAnsclicked);
        }
        else if (selected == 3) {
            //userAnser = document.getElementById("buttonC").innerText;
            //alert("Option C Selected");
            userAnswer = "c";
            questGen.clickCheckAnswer(userAnswer, qAnsclicked);
        }
        else if (selected == 4) {
            //userAnser = document.getElementById("buttonD").innerText;
            //alert("Option D Selected");
            userAnswer = "d";
            questGen.clickCheckAnswer(userAnswer, qAnsclicked);
        }

    }


   


    this.randomNumberGenerator = function () {
        this.questionCount = 10;
        /*for (var loop = 0; loop < questionCount; loop++) {
            do {
                randomNumber = Math.floor(Math.random() * questionCount);
            } while (!exists[randomNumber]);
            exists[randomNumber] = true;
            randNum[loop] = randomNumber;
            //alert(randomNumber)
        }*/
        
        for (var loop = 0; loop < this.questionCount; loop++) {
            do {
                this.randomNumber = Math.floor(Math.random() * this.questionCount);
                //alert("hate you");        
            } while (this.exists[this.randomNumber]);
            this.exists[this.randomNumber] = true;
            this.randNum[loop] = this.randomNumber;
            //alert(randomNumber)
        }
        /*
        var test = "";

        for (var loop = 0; loop < this.questionCount; loop++) {
            test += this.randNum[loop] + "  ";

        }
        alert(test);
        */
    }

    
    this.Question = function () {
        //alert("Question Test");

        var counter = parseInt(document.getElementById("QuestionCountLabel").innerText);
        this.questionTimeStart = utils.getTime();
        //alert(this.questionTimeStart);
        //alert(counter);
        if (counter < 10) {
           
            //questionCount = parseInt(document.getElementById("questionCounterLabel").innerHTML);
            //alert("this is the counter: " + this.randNum[this.counter]);

            //alert(questionCount);
            //randomNumber = Math.floor(Math.random() * 10);
            //randomNumber = ;
            //alert(randomNumber);
            var optASel = document.getElementById("optionASelect");
            var questSel = document.getElementById("questionSelect");
            var optASel = document.getElementById("optionASelect");
            var optBSel = document.getElementById("optionBSelect");
            var optCSel = document.getElementById("optionCSelect");
            var optDSel = document.getElementById("optionDSelect");
            var ansSel = document.getElementById("answerSelect");
            var check = optDSel.options[this.randNum[this.counter]].innerHTML.length;
            var oC = document.getElementById("OptionC");
            var oD = document.getElementById("OptionD");
            var targetSprite2 = document.getElementById("targetSprite2");
            //alert("check 1:"+check);
            if (check == 2) {
                var oC = document.getElementById("OptionC");
                var oD = document.getElementById("OptionD");

                oC.style.display = "none";
                oD.style.display = "none";
                targetSprite2.style.display = "none";
            } else {
                var optionA = document.getElementById("OptionA");
                if (optionA.style.display = "block") {
                    oC.style.display = "block";
                    oD.style.display = "block";
                    targetSprite2.style.display = "block";
                }
            }

            document.getElementById("questionLabel").innerHTML = questSel.options[this.randNum[this.counter]].innerHTML;
            document.getElementById("buttonA").innerHTML = optASel.options[this.randNum[this.counter]].innerHTML;
            document.getElementById("buttonB").innerHTML = optBSel.options[this.randNum[this.counter]].innerHTML;
            document.getElementById("buttonC").innerHTML = optCSel.options[this.randNum[this.counter]].innerHTML;
            document.getElementById("buttonD").innerHTML = optDSel.options[this.randNum[this.counter]].innerHTML;
            document.getElementById("answerLabel").innerHTML = ansSel.options[this.randNum[this.counter]].innerHTML;

            //alert("this is the counter: " + randNum[counter]);
            this.counter++;

        } else {
            //alert("Max Questions"); 


            stopGame();
            var endgame = document.getElementById("gameEndBackGround");
            var question = document.getElementById("QuestionArea");
            var optionA = document.getElementById("OptionA");
            var optionB = document.getElementById("OptionB");
            var optionC = document.getElementById("OptionC");
            var optionD = document.getElementById("OptionD");
            var targetSprite = document.getElementById("targetSprite");
            var gamePoints = document.getElementById("gamePoint");
            var enq = document.getElementById("gameEnqueryBackGround");

            question.style.display = "none";
            optionA.style.display = "none";
            optionB.style.display = "none";
            optionC.style.display = "none";
            optionD.style.display = "none";
            targetSprite.style.display = "none";
            enq.style.display = "none";
            gamePoints.style.display = "none";

            endgame.style.display = "block";

        }
    }
}