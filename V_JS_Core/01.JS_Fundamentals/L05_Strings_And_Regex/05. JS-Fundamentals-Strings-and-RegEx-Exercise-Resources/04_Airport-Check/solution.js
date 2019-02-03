function solve() {
    let resultElement = document.getElementById('result');
    let input = document.getElementById('str').value.split(', ').filter(x => x !== '');
    let info = input[0];
    let command = input[1];
    
    let flight = getFlightInfo(info);

    printMessage(command, flight)

    function printMessage(command, flight){        
        let airportInfo = flight.airport.split('/');

        let messages = {
        name : `Mr/Ms, ${flight.passengerName}, have a nice flight!`,
        flight : `Your flight number ${flight.flightNumber} is from ${airportInfo[0]} to ${airportInfo[1]}.`,
        company : `Have a nice flight with ${flight.company}.`,
        all : `Mr/Ms, ${flight.passengerName}, your flight number ${flight.flightNumber} is from ${airportInfo[0]} to ${airportInfo[1]}. Have a nice flight with ${flight.company}.`,
        };

        resultElement.textContent = messages[command];   
    }

    function getFlightInfo(info){

        let passengerNamePattern = / (([A-Z]+([A-Za-z]*)?)(-[A-Z][A-Za-z]*\.)?-([A-Z][A-Za-z]*)?) /;
        let airportPattern = / ([A-Z]{3}\/[A-Z]{3}) /;
        let flightNumberPattern = / ([A-Z]{1,3}\d{1,5}) /;
        let companyPattern = /- ([A-Z][A-Za-z]*\*[A-Z][A-Za-z]*) /;

        let flightInfo = {
            passengerName : info.match(passengerNamePattern)[1].replace(/\-/g, ' ').trim(),
            airport : info.match(airportPattern)[1],
            flightNumber : info.match(flightNumberPattern)[1].trim(),
            company : info.match(companyPattern)[1].replace(/\-/g, '').replace('*', ' ').trim()
        };

        return flightInfo; 
    }  
}