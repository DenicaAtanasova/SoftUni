function getNext() {

    let result = document.getElementById('result');

    let num = +document.getElementById('num').value;
    
    result.textContent = hailStoneSeq() + ' ';

    function hailStoneSeq(){  
        let seq = [num];

        while (num !== 1){
            if (num % 2 === 0 ) num /= 2;
            else num = (num * 3) + 1;
    
            seq.push(num);
        }
    
        return seq.join(' ');
    }
}