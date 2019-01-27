function validate() {
    
    document.querySelector('button').addEventListener('click', ()=>{

        let inputElement = document.querySelector('input[type="number"]');
        let numbers = inputElement.value.split('');

        let response = document.getElementById('response');

        if(isValidInput(numbers)){
            response.textContent = 'This number is Valid!';
        } else{
            response.textContent = 'This number is NOT Valid!';
        }
    });

    function calculateWeight(numbers){

        let weights = [2, 4, 8, 5, 10, 9, 7, 3, 6];
        let weight = 0;

        for(let i = 0; i < weights.length; i++){
            weight+= +numbers[i] * weights[i];
        }
        return weight;
    }

    function isValidInput(numbers){

        let weight = calculateWeight(numbers);
        let reminder = weight % 11 < 10 ? weight % 11 : 0;

        return +numbers[numbers.length - 1] === reminder;
    }
}