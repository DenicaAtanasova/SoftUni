function solve(){
  
  let inputElement = document.getElementById('input');
  let textToFormat = inputElement.innerHTML.split('.').filter(sentance => sentance.length !== 0);

  let outputElement = document.getElementById('output');

  while(textToFormat.length > 0){

    let length = textToFormat.length < 3 ? textToFormat.length : 3;

    let formatedText = textToFormat.slice(0, length);

    let outputParagraph = document.createElement('p');

    outputParagraph.textContent = formatedText;

    outputElement.appendChild(outputParagraph);

    textToFormat = textToFormat.slice(length);
  }
}