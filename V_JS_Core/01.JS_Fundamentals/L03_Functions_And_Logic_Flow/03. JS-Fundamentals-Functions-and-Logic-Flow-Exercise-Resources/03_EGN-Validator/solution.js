function validate() {

    let EGN = [];
    
    let yearElement = document.getElementById('year');
    let monthElement = document.getElementById('month');
    let dateElement = document.getElementById('date');
    let regionElement = document.getElementById('region');

    document.querySelector('button').addEventListener('click', generateEGN);

    function generateEGN(){ 
        let year = +yearElement.value;
        if(year >= 1900 && year <= 2100){
            fillDateToEGN(year % 100, 0);
        }

        let month = monthElement.selectedIndex;
        fillDateToEGN(month, 2);

        let date = +dateElement.value;
        if(date >= 1 && date <= 31){
            fillDateToEGN(date, 4);
        }
        
        let region = +regionElement.value;
        if(region >= 43 && region <= 999){
            regionNum = region.toString().length > 2 ? region / 10 | 0 : region
            fillDateToEGN(regionNum, 6);
        }

        let genderBtn = document.document.querySelector('input:checked');
        if(genderBtn.value === 'Male'){
            EGN[8] = 2;
        } else {
            EGN[8] = 1;
        }

        EGN[9] = calculateWeight(EGN);

        clearInput();
    }

    function fillDateToEGN(date, index){
        EGN[index] = date / 10 | 0;
        EGN[index + 1] = date % 10;
    }

    function calculateWeight(){
        let weightPosition = [2, 4, 8, 5, 10, 9, 7, 3, 6];   
        let weightSum = 0;
    
        for(let i = 0; i < 9; i++){
            weightSum += weightPosition[i] + EGN[i];
        }
    
        let checkSum = weightSum % 11;
    
        return checkSum > 9 ? 0 : checkSum;
    }
    
    function clearInput(){
        yearElement.value = '';
        monthElement.selectedIndex = 0;
        dateElement.value = '';
        let genderBtn = document.document.querySelector('input:checked');
        genderBtn.checked = false;
    }
}

