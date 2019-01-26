function solve() {
   Array.from(document.getElementsByTagName('button')).forEach(btn =>{
      btn.addEventListener('click', action)
   });

   function action(e){
      let parent = e.target.parentNode;
      let unlockBtn = parent.querySelector('input[type="radio"][value="unlock"]');

      if(unlockBtn.checked){

         let divElement = parent.querySelector('div[id^="user"]');

         if(this.textContent === 'Show more'){
            divElement.style.display = 'block';
            this.textContent = 'Hide it';

         } else {
            divElement.style.display = 'none';
            this.textContent = 'Show more';
         }    
      }
   }
}