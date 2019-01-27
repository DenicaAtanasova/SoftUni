function solve() {
    let inputElement = document.querySelector('input[type="number"]');

    let number;

    let funcs = [
        function chop(number){return number / 2;}, 
        function dice(number){return Math.sqrt(number);},
        function spice(number){return ++number;},
        function bake(number){return number * 3;},
        function fillet(number){return number * 0.8;}];

    let output = document.getElementById('output');

    let buttonElements = document.querySelectorAll('#operations>button');

    for(let i = 0; i < funcs.length; i++){   
        buttonElements[i].addEventListener('click', ()=>{
            output.textContent = funcs[i](getNumberValue());
        });
    }

    function getNumberValue(){
        if(output.textContent.length === 0){
            number = inputElement.value.length === 0 ? 0 : inputElement.value;
        } else{
            number = +output.textContent;
        }
        return number;
    }
}