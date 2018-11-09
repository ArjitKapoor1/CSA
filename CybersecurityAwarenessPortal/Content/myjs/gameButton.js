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

function buttonOnClickAction(selected) {
    var qAns = document.getElementById("questionAnswer").innerText;

    var userAnser = "";

    //alert(qAns);

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