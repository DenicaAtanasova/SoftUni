function solve() {
   let inputElement = document.getElementById('input');
   let outputElement = document.querySelector('#output p');

   Array.from(document.querySelectorAll('button')).forEach(btn =>{
      btn.addEventListener('click', () => getFunction(btn.innerHTML.toLowerCase()));
   });
    
   function getFunction(functionType) {     
      eval(functionType)();
   }

   function filter(){
      
      let command = getSecondCommand("filterSecondaryCmd");
      let positionElement = document.getElementById('filterPosition');
      let result;
      switch(command){
         case'UPPERCASE': 
            result = inputElement.value.split('').filter(x => x.toUpperCase() === x); 
            break;
         case'LOWERCASE': 
            result = inputElement.value.split('').filter(x => x.toLowerCase() === x); 
            break;
         case'NUMS': 
            result = inputElement.value.split('').filter(x => !isNaN(x)); 
            break;
         default: 
            result = inputElement.value;
            break;
      }
      
      inputElement.value = '';
      outputElement.textContent += result[+positionElement.value - 1];
   }

   function sort(){
      console.log('sort');
      inputElement.nodeValue = '';
   }

   function rotate(){
      console.log('rotate');
      inputElement.nodeValue = '';
   }

   function get(){
      console.log('get');
      inputElement.nodeValue = '';
   }

   function getSecondCommand(id){
      let secondaryCommandElement = document.getElementById(id);
      return secondaryCommandElement.item(secondaryCommandElement.selectedIndex).innerHTML;
   }
}