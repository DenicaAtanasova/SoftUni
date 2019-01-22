function solve() {
	let inputTitleElement = document.getElementById('createTitle');
	let inputContentElement = document.getElementById('createContent');

	let inputTitleValue = inputTitleElement.value;
	let inputContentValue = inputContentElement.value;

	if(inputTitleValue && inputContentValue){
		let outputTitleElement = document.createElement('h3');
		outputTitleElement.textContent = inputTitleValue;
		
		let outputContentElement = document.createElement('p');
		outputContentElement.textContent = inputContentValue;

		let articleElement = document.createElement('article');
		articleElement.appendChild(outputTitleElement);
		articleElement.appendChild(outputContentElement);

		let articlesElement = document.getElementById('articles');
		articlesElement.appendChild(articleElement);

		inputTitleElement.value = '';
		inputContentElement.value = '';
	}
}