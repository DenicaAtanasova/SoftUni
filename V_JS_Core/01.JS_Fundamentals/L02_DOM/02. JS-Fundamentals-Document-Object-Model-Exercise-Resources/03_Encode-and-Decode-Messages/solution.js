function solve() {

	Array.from(document.getElementsByTagName('button')).forEach(btn => {
		btn.addEventListener('click', encodeOrDecode)
	});

	function encodeOrDecode(e){
		
		let action = e.target.textContent.split(' ')[0];

		let textAreaElements = document.querySelectorAll('textarea');

		let inputArea = action === 'Encode' ? textAreaElements[0] : textAreaElements[1];
		let outputArea = textAreaElements[1];
		
		let inputMessage = inputArea.value.split('');
		
		let outputMessage = [];

		for(let char of inputMessage){

			let encodedOrDecodedChar = action === 'Encode' ? 
												char.charCodeAt() + 1 : 
												char.charCodeAt() - 1;

			outputMessage.push(String.fromCharCode(encodedOrDecodedChar));
		}

		inputArea.value = '';
		outputArea.value = outputMessage.join('');
	}
}