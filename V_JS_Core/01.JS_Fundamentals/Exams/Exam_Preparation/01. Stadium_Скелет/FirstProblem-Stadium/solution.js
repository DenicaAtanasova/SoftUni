function solve() {
    let ticketsSold = [];
    let outputElement = document.getElementById('output');
    Array.from(document.querySelectorAll('.seat')).forEach(btn => btn.addEventListener('click', selectSeat));

    function selectSeat(e){
        
        let sectionElement = e.target.parentElement.parentElement.parentElement.parentElement.parentElement;
        let tableElement = e.target.parentElement.parentElement.parentElement.parentElement;
        let cellIndex = e.target.parentElement.cellIndex;

        let zone = sectionElement.className;
        let sector = tableElement.querySelectorAll('th')[cellIndex].textContent;
        let seat = e.target.textContent;
           
        if(e.target.style.backgroundColor === ''){
            e.target.style.backgroundColor = 'rgb(255,0,0)';
            outputElement.textContent += ` Seat ${seat} in zone ${zone} sector ${sector} was taken.\n`;
            ticketsSold.push(calculateProfit(zone, sector));
        } else {
            outputElement.textContent += ` Seat ${seat} in zone ${zone} sector ${sector} is unavailable.\n`;          
        }  
    }

    function calculateProfit(zone, sector){
        
        switch(sector){
            case 'A': return zone === 'VIP' ? 25 : 10;
            case 'B': return zone === 'VIP' ? 15 : 7;
            default: return zone == 'VIP' ? 10 : 5;
        }
    }

    let summaryElement = document.getElementById('summary');

    summaryElement.querySelector('button').addEventListener('click', () => {
        let profit = ticketsSold.reduce((a,b) => a+b);
        let fansCount = ticketsSold.length;

        summaryElement.querySelector('span').textContent = `${profit} leva, ${fansCount} fans.`;
    });
}