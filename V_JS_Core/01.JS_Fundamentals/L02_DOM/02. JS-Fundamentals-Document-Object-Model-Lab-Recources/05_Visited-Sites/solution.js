function solve() {

  let linkElements = document.querySelectorAll('#exercise div');

  for (let element of linkElements){
    
    element.getElementsByTagName('a')[0].addEventListener('click', function () {

      let spanElement = element.getElementsByTagName('span')[0];

      let count = Number(spanElement.textContent.match(/\d+/));

      spanElement.textContent = spanElement.textContent.replace(/\d+/, ++count);
    });
  }
}

