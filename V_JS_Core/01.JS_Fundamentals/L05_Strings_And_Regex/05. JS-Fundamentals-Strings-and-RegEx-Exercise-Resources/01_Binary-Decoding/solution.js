function solve() {

  let resultElement = document.getElementById('result');
  let input = document.getElementById('str').value;

  let stringToDecode = trimString(countToSlice(input));

  resultElement.textContent = decodeString(stringToDecode);    
  
  function countToSlice(input){
    let sum = input
                .split('')
                .map(Number)
                .reduce((a, b) => a + b, 0);

    while (sum > 9) {
      let lastDigit = sum % 10;
      sum = (sum / 10 | 0) + lastDigit;
    }
    return sum;
  }

  function trimString(sliceCount){
    return input.slice(sliceCount, -sliceCount);
  } 

  function decodeString(encodedString){
    let result = '';
    
    while(encodedString.length !== 0) {

      var digit = parseInt(encodedString.substr(0, 8), 2);
      encodedString = encodedString.slice(8);

      if((digit >= 65 && digit <= 90) ||
         (digit >= 97 && digit <= 122) ||
          digit === 32){

        let decodedChar = String.fromCodePoint(digit)    
        result += decodedChar;
      }            
    }
    return result;
  }
}