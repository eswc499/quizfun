var currentQuestion = 0;
var score = 0;
var totQuestions = questions.length;

var container=document.getElementById('quizContainer');
var questionEl=document.getElementById('question');
var opt1=document.getElementById('opt1');
var opt2=document.getElementById('opt2');
var opt3=document.getElementById('opt3');
var opt4=document.getElementById('opt4');
var nextButton = document.getElementById('nextButton');
var com=document.getElementById('Comprob');
var resultCont = document.getElementById('result');
var contador = document.getElementById('contador');

function loadQuestion (questionIndex){
	var q = questions[questionIndex];
	questionEl.textContent=(questionIndex + 1) + '.' + q.question;
	opt1.textContent= q.option1;
	opt2.textContent= q.option2;
	opt3.textContent= q.option3;
	opt4.textContent= q.option4;
	contador.textContent=q.contador;
}

function loadNextQuestion(){
	var selectedOption = document.querySelector('input[type=radio]:checked');
	if(!selectedOption){
		alert('Por favor, elija una opción');
		return;
	}
	var answer = selectedOption.value;
	if(questions[currentQuestion].answer == answer){
		score +=2	;
	}
	
	selectedOption.checked = false;
	currentQuestion++;
	if(currentQuestion === totQuestions -1){
		nextButton.textContent = 'Finalizar';
	}
	
	if(currentQuestion === totQuestions){
		container.style.display='none';
		resultCont.style.display= '';
		com.style.display='none';
		hz.style.display='';
		if(score>10){
			resultCont.textContent = 'Tu Nota: ' + score;
			com.textContent='Felicidades! Aprobó el curso';
		}
		if(score<=10){
			resultCont.textContent = 'Tu Nota: ' + score
			com.textContent= 'Lo sentimos, tendrá que repetir el curso';
            
		}
		return;
	}
	
	loadQuestion(currentQuestion);
}

loadQuestion(currentQuestion);