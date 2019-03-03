function timer() {
   let seconds = 0;
   let timer;
   let isWorking = false;

   $('#start-timer').on('click', function () {
      if (!isWorking) {
         timer = setInterval(step, 1000);
         isWorking = true;
      }
   });

   $('#stop-timer').on('click', function () {
      clearInterval(timer);
      isWorking = false;
   });

   function step() {
      seconds++;

      $('#hours').text(('0' + Math.trunc(seconds / 3600)).slice(-2));
      $('#minutes').text(('0' + Math.trunc((seconds / 60) % 60)).slice(-2));
      $('#seconds').text(('0' + Math.trunc(seconds % 60)).slice(-2));
   }
}