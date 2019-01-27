function solve() {
    let cardsElement = document.getElementById('cards');
    let fromElement = document.getElementById('from');
    let toElement = document.getElementById('to');
    let select = document.querySelector('select');

    let cards = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];

    document.querySelector('button').addEventListener('click', ()=>{
        let startIndex = cards.indexOf(fromElement.value);
        let endIndex = cards.indexOf(toElement.value);

        for(let i = startIndex; i <= endIndex; i ++){
            let divElement = document.createElement('div');
            divElement.classList.add('card');

            let cardSuit = select.children[select.selectedIndex].innerHTML.split(' ')[1];
            
            appendCardElement(divElement, cardSuit);
            appendCardElement(divElement, cards[i]);
            appendCardElement(divElement, cardSuit);   
            
            cardsElement.appendChild(divElement);
        }

        fromElement.value = '';
        toElement.value = '';
    });

    function appendCardElement(divElement, cardSuit){
        let pElement = document.createElement('p');
            pElement.innerHTML = cardSuit;

            divElement.appendChild(pElement);
    }
}