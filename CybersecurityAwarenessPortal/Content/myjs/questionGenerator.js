var questGen = new questionGenerator();

function titi() {
    alert("Quest Test");
}

function questionGenerator() {
    this.exists = [],
        this.randomNumber,
        this.max = 10,
        this.counter = 0,
        this.randNum = [],
        this.questionCount;

    this.questionCounter = function () {
        var counter = parseInt(document.getElementById("QuestionCountLabel").innerText) + 1;
        document.getElementById("QuestionCountLabel").innerText = counter;
    }

    this.correctAnswer = function () {
        var right = parseInt(document.getElementById("CorrectLabel").innerText) + 1;
        document.getElementById("CorrectLabel").innerHTML = right;

        var s = document.getElementById("userCorrectLabel");
        var calculate = (right / 10) * 100;

        s.value = "" + (right / 10) * 100;

        var previousAttempt = parseInt(document.getElementById("attemptLabel").innerText) + 1;
        var currentAttempt = document.getElementById("currentAttemptLabel");
        //alert(previousAttempt);
        currentAttempt.value = "" + previousAttempt;

        if (calculate >= 80) {
            var pass = document.getElementById("passfail");
            pass.innerHTML = "PASSED";
            pass.style.color = "yellow";
        } else {
            var fail = document.getElementById("passfail");
            fail.innerHTML = "FAILED";
            fail.style.color = "red";
        }

        var ca = document.getElementById("stats");
        ca.innerHTML = "Correct!!"
        ca.style.color = "yellow";


        document.getElementById("enqueryQuestion").innerHTML = document.getElementById("questionLabel").innerHTML;
        document.getElementById("EnqueryOption").innerHTML = "Congratulation, You Answered Correctly.";

        questGen.questionCounter();

        var enq = document.getElementById("enquery");

        var question = document.getElementById("QuestionArea");
        var optionA = document.getElementById("OptionA");
        var optionB = document.getElementById("OptionB");
        var optionC = document.getElementById("OptionC");
        var optionD = document.getElementById("OptionD");
        var targetSprite = document.getElementById("targetSprite");

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
        qAns = qAns.substr(1, 1);
        //alert("=" + ans + "=");
        //document.getElementById("EnqueryOption").innerHTML = document.getElementById("buttonA").innerHTML;
        if (qAns == "a") {

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

        var wrong = parseInt(document.getElementById("IncorrectLabel").innerText) + 1;

        var ca = document.getElementById("stats");
        ca.innerHTML = "Incorrect!!"
        ca.style.color = "red";
        ca.style.fontSize = "25px";

        document.getElementById("enqueryQuestion").innerHTML = document.getElementById("questionLabel").innerHTML;
        document.getElementById("IncorrectLabel").innerHTML = wrong;
        questGen.questionCounter();
        var enq = document.getElementById("enquery");

        var question = document.getElementById("QuestionArea");
        var optionA = document.getElementById("OptionA");
        var optionB = document.getElementById("OptionB");
        var optionC = document.getElementById("OptionC");
        var optionD = document.getElementById("OptionD");
        var targetSprite = document.getElementById("targetSprite");

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
            questGen.correctAnswer();
            //alert(userAnser);

        }
        else {
            //alert("check Incorrect Answer");
            questGen.incorrectAnswer(qAns);
            //alert("The Right Answer is: \n" + qAns + "\n\nPlease, Press Enter or Click To Process");

        }

    }

    this.testQuest = function () {
        alert("Quest");
    }

    this.shootResult = function (selected) {
        var qAns = document.getElementById("answerLabel").innerHTML;

        qAns = qAns.substr(1, 1);
        var userAnser = "";

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

    this.randomQuestion = function () {
        /*
        if (num == 1) {
            if (counter == 0) {
            }
            else {
                counter--;
            }
        }
        if (num == 2) {
            if (counter == max) {
            }
            else {
                counter++;
            }
        }*/
        if (counter != max) {
            counter++;
            var questSel = document.getElementById("questionSelect");
            var optASel = document.getElementById("optionASelect");
            var optBSel = document.getElementById("optionBSelect");
            var optCSel = document.getElementById("optionCSelect");
            var optDSel = document.getElementById("optionDSelect");
            var ansSel = document.getElementById("answerSelect");

            document.getElementById("CorrectTitle").innerHTML = questSel.options[randNum[counter]].innerHTML;
            document.getElementById("buttonA").innerHTML = optASel.options[randNum[counter]].innerHTML;
            document.getElementById("buttonB").innerHTML = optBSel.options[randNum[counter]].innerHTML;
            document.getElementById("buttonC").innerHTML = optCSel.options[randNum[counter]].innerHTML;
            document.getElementById("buttonD").innerHTML = optDSel.options[randNum[counter]].innerHTML;
            document.getElementById("AttemptLabel").innerHTML = ansSel.options[randNum[counter]].innerHTML;

        }
    }

    this.Question = function () {
        //alert("Question Test");
        if (this.counter >= 10) {
            stopGame();
            var endgame = document.getElementById("endgamepage");
            var question = document.getElementById("QuestionArea");
            var optionA = document.getElementById("OptionA");
            var optionB = document.getElementById("OptionB");
            var optionC = document.getElementById("OptionC");
            var optionD = document.getElementById("OptionD");
            var targetSprite = document.getElementById("targetSprite");
            var enq = document.getElementById("enquery");

            question.style.display = "none";
            optionA.style.display = "none";
            optionB.style.display = "none";
            optionC.style.display = "none";
            optionD.style.display = "none";
            targetSprite.style.display = "none";
            enq.style.display = "none";

            endgame.style.display = "block";
        } else {
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
        }
    }

}