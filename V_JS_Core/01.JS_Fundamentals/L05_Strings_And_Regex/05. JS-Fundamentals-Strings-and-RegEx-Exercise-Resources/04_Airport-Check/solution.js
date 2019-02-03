function solve() {
    let resultElement = document.getElementById('result');
    let input = document.getElementById('str').value.split(', ').filter(x => x !== '');
    let info = input[0];
    let command = input[1];
    
    let flightInfo = getFlightInfo(info);

    printMessage(command, flightInfo)

    function printMessage(command, flightInfo){        
        let airportInfo = flightInfo.airport.split('/');
        
        let messages = {
            name : `Mr/Ms, ${flightInfo.passengerName}, have a nice flight!`,
            flight : `Your flight number ${flightInfo.flightNumber} is from ${airportInfo[0]} to ${airportInfo[1]}.`,
            company : `Have a nice flight with ${flightInfo.company}.`,
            all : `Mr/Ms, ${flightInfo.passengerName}, your flight number ${flightInfo.flightNumber} is from ${airportInfo[0]} to ${airportInfo[1]}. Have a nice flight with ${flightInfo.company}.`,
        };

        resultElement.textContent = messages[command];   
    }

    function getFlightInfo(info){

        let passengerNamePattern = / (([A-Z]+([A-Za-z]*)?)(-[A-Z][A-Za-z]*\.)?-([A-Z][A-Za-z]*)?) /;
        let airportPattern = / ([A-Z]{3}\/[A-Z]{3}) /;
        let flightNumberPattern = / ([A-Z]{1,3}\d{1,5}) /;
        let companyPattern = /- ([A-Z][A-Za-z]*\*[A-Z][A-Za-z]*) /;

        let flightInfo = {
            passengerName : info.match(passengerNamePattern)[1].replace(/\-/g, ' '),
            airport : info.match(airportPattern)[1],
            flightNumber : info.match(flightNumberPattern)[1],
            company : info.match(companyPattern)[1].replace('*', ' ')
        };

        return flightInfo; 
    }  
}