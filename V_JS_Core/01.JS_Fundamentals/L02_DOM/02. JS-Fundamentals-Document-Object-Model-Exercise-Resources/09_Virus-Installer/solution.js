function solve() {

    let contentElement = document.getElementById('content');
    
    let buttonElements = document.getElementById('buttons');

    let nextBtnElement = buttonElements.firstElementChild;
    let cancelBtnElement = buttonElements.lastElementChild;

    nextBtnElement.addEventListener('click', nextAction);
    cancelBtnElement.addEventListener('click', finishAction);

    let clicksCount = 1;

    function nextAction(){
        
        if(clicksCount === 1){
            switchStep();

        }else if(clicksCount === 2){

            let agreeBtn = document.querySelector('input[type="radio"][value="agree"]');

            if(agreeBtn.checked){

                hideBtn();
                showBtn();

                switchStep();
            } else{
                return;
            }

        } else if(clicksCount === 3){

            hideBtn();
            cancelBtnElement.textContent = 'Finish';

            switchStep();
        }

        clicksCount++;
    }

    function switchStep() {
        if (clicksCount === 1) {
            contentElement.style.background = 'none';
        } else{
            contentElement.children[clicksCount - 2].style.display = 'none';
        }

        contentElement.children[clicksCount - 1].style.display = 'block';
    }

    function hideBtn(){
        nextBtnElement.style.display = 'none';        
    }

    function showBtn(){
        setTimeout(() => {
            nextBtnElement.style.display = 'inline-block';
        }, 3000);
    }

    function finishAction(){
        let sectionElement = document.querySelector('#exercise>section');
        sectionElement.style.display = 'none';
    }
}