function solve() {
  
  let resultElement = document.getElementById('result');
  let paragraphElement = document.createElement('p');

  let input = JSON.parse(document.getElementById('arr').value);
  
  let specialKey = input.shift();
  let text = input.join('\n');

  appendDecodedParagraph(decode(specialKey, text));
  
  function decode(specialKey, text){
    let decoder = ['!', '%', '#', '$'];
    let regex = new RegExp(`(\\s|^)(${specialKey}\\s+)([A-Z!#$%]{8,})(\\.|,|\\s|$)`, 'gi');
    
    let match;
    while(match = regex.exec(text)){
      
      if(match[3] === match[3].toUpperCase()){
        let decodedString = match[3].split('')
                            .map(x => {
                              if(decoder.includes(x)){
                                return decoder.indexOf(x) + 1;
                              }
                              else{
                                return x.toLowerCase();
                              }
                            })
                            .join('');

      text = text.replace(match[3], decodedString);
      }
    }

    return text;
  }

  function appendDecodedParagraph(decodedString){
    
    decodedString.split('\n')
                 .forEach(line => {
                    let pElement = paragraphElement.cloneNode();
                    pElement.textContent = line;
                    resultElement.appendChild(pElement);
                 });
  }
}