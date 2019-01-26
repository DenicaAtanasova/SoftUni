function solve() {

	let exerciseElements = document.querySelectorAll('#exercise section');
	let correctAnswers = ['2013', 'Pesho', 'Nakov'];
	let correctAnswersCount = 0;
		
	let btnElements = document.getElementsByTagName('button');

	for(let i = 0; i < 3; i++){

		btnElements[i].addEventListener('click', func)

		function func(){

		let answer = Array.from(exerciseElements[i]
			.getElementsByTagName('input'))
			.filter(x => x.checked)[0];

			if(answer){

				if(correctAnswers[i] === answer.value){
					correctAnswersCount++;
				}

				let resultElement = document.getElementById('result');

				if(i < exerciseElements.length - 1){
						let hiddenElement = document.getElementsByClassName('hidden')[i];
						hiddenElement.style.display = 'block';
				}else{
						resultElement.innerHTML = correctAnswersCount < 3 ?
												`You have ${correctAnswersCount} right answers` :
												'You are recognized as top SoftUni fan!';
				}
			}
		}
	}	
}