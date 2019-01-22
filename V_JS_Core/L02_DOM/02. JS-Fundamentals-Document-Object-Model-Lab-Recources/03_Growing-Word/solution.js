function solve() {
   let clicks = 0;
   
   document.querySelector('button').addEventListener('click', 
   () => {
      let growingWorldElement = document.querySelector('#exercise p');

      if(clicks % 3 === 0){
         growingWorldElement.style.color = 'blue';
      } else if(clicks % 3 === 1){
         growingWorldElement.style.color = 'green';
      }else if(clicks % 3 === 2){
         growingWorldElement.style.color = 'red';
      }

      clicks++;
      growingWorldElement.style.fontSize = `${clicks * 2}px`;
   });
}