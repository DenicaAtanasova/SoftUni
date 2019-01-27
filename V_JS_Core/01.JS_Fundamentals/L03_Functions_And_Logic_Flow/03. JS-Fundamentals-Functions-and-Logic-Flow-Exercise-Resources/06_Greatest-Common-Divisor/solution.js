function greatestCD() {

    let firstNum = +document.getElementById('num1').value;
    let secondNum = +document.getElementById('num2').value;

    let result = document.getElementById('result');

    result.textContent = gcd(firstNum, secondNum);

    function gcd (a, b) {
        if ( ! b) {
            return a;
        }

        return gcd(b, a % b);
    };
}