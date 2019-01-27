function solve() {
   let num = +document.getElementById('num').value;
   let resultElement = document.getElementById('result');

   let factors = number => Array
      .from({length: number + 1}, (v, i) => i)
      .filter(i => number % i === 0);

   resultElement.textContent = factors(num).join(' ');
}