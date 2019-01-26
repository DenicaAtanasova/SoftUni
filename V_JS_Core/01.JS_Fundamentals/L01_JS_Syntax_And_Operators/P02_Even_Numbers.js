function PrintEvenNumbersInARange(lastNum){
   for (let i = 1; i <= lastNum; i++){
       if (i % 2 === 0) {
           console.log(i);
       }
   }
}

PrintEvenNumbersInARange(7);