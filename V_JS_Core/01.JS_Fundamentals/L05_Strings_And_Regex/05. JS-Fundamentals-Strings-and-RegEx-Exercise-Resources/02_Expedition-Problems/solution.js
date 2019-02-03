function solve() {
  let keyword = document.getElementById('str').value;
  let text = document.getElementById('text').value;
  
  let resultElement = document.getElementById('result');
  let paragraphElement = document.createElement('p');
   
  findCoordinates(text);
  findMessage(keyword, text);

  function findCoordinates(text){
    let coordinatesPattern = /(east|north).*?([\d]{2})[^,]*,[^,]*?([\d]{6})/gi;
    let match;

    let latitude;
    let longitude;

    while (match = coordinatesPattern.exec(text)) {
      console.log(match);
      let direction = match[1].toLowerCase();

      switch(direction){
        case 'north': 
        latitude = `${match[2]}.${match[3]} N`;
        break;
        case 'east':
        longitude = `${match[2]}.${match[3]} E`;
        break;
      }
    }

    appendToParent(latitude);
    appendToParent(longitude);
  }
  
  function findMessage(keyword, text){
    let regEx = new RegExp(`${keyword}(.*?)${keyword}`, "g");

    let message = `Message: ${regEx.exec(text)[1]}`;
    appendToParent(message);
  }

  function appendToParent(text) {
    let p = paragraphElement.cloneNode();
    p.textContent = text;
    resultElement.appendChild(p);
  }
}