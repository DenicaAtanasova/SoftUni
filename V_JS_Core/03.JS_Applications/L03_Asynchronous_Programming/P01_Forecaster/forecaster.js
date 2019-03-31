function attachEvents(){

    let conditionSymbols = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂'
    };

    const baseUrl = 'https://judgetests.firebaseio.com/';

    $('#submit').on('click', GetWeather);

    async function GetWeather(){    
        try {
            let weather = await $.get(baseUrl + 'locations.json')
                                 .then();

            let city = $('#location').val();
            let code = weather.filter(c => c.name === city)[0].code;

            let currentForecastUrl = baseUrl + `forecast/today/${code}.json`;
            let currentForecast = await $.get(currentForecastUrl)
                                         .then();
                                         
            let upcomingForecastUrl = baseUrl + `forecast/upcoming/${code}.json`;
            let upcomingForecast = await $.get(upcomingForecastUrl)
                                        .then();

            $('#forecast').show();

            renderCurrentForecast(currentForecast);
            renderUpcamingForecast(upcomingForecast);

        } catch (error) {
            console.log(error);           
        }          
    }

    function renderCurrentForecast(currentForecast){
        let city = currentForecast.name;
        let degrees = `${currentForecast.forecast.low}°/${currentForecast.forecast.high}°`;
        let condition = currentForecast.forecast.condition;

        $('#current')
            .append($('<span>').addClass('condition symbol').text(conditionSymbols[condition]))
            .append($('<span>').addClass('condition')
                .append($('<span>').addClass('forecast-data').text(city))
                .append($('<span>').addClass('forecast-data').text(degrees))
                .append($('<span>').addClass('forecast-data').text(condition))
        );
    }

    function renderUpcamingForecast(upcamingForecast){

        for (let i = 0; i < upcamingForecast.forecast.length; i++) {
            let degrees = `${upcamingForecast.forecast[i].low}°/${upcamingForecast.forecast[i].high}°`;
            let condition = upcamingForecast.forecast[i].condition;

            $('#upcoming')
                    .append($('<span>').addClass('upcoming')
                        .append($('<span>').addClass('symbol').text(conditionSymbols[condition]))
                        .append($('<span>').addClass('forecast-data').text(degrees))
                        .append($('<span>').addClass('forecast-data').text(condition))
                    );
        }
    }
} 