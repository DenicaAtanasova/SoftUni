function leapYear() {

    document.querySelector('button').addEventListener('click', () => {
        let year = document.querySelector('input[type="number"]');
        let h2Element = document.querySelector('#year > h2');
        let divElement = document.querySelector('#year > div');

        divElement.textContent = year.value;

        if(isleapYear(year.value)){
            h2Element.textContent = 'Leap Year';
        } else{
            h2Element.textContent = 'Not Leap Year';
        }
        
        year.value = ''; 
    });

    function isleapYear(year)
    {
      return ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);
    }
}