function solve() {

	let inputElement = document.querySelector('input[type="text"]');
	let allNumbersDivElement = document.querySelector('div#allNumbers');

	let btnElement = document.querySelector('button');

	btnElement.addEventListener('click', () => {;

		let input = inputElement.value;

		if(isInputCorrect(input)){

			fillDivTable(input);

			btnElement.disabled = true;
			inputElement.disabled = true;
		}	
	});

	function isInputCorrect(input){

		let result = false;
		let numbers = input.split(' ');

		if(numbers.length === 6){
			result = true;

			for(let number of numbers){

				if(number < 1 || number > 49){
					result = false;
					break;
				}
			}
		}

		return result;
	}

	function fillDivTable(input){

	   	for(let i = 1; i <= 49; i++){

	   		let divElement = document.createElement('div');
			divElement.textContent = `${i}`;
			divElement.classList.add('numbers');

			if(input.includes(`${i}`)){
				divElement.style.background = 'orange';
			}

	  		allNumbersDivElement.appendChild(divElement);
	   	}
	}
}