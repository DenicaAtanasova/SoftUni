function attachEventsListeners() {

const converterToMeter = {
    km : (value) => value * 1000,
    m : (value) => value * 1,
    cm : (value) => value * 0.01,
    mm : (value) => value * 0.001,
    mi : (value) => value * 1609.34,
    yrd : (value) => value * 0.9144,
    ft : (value) => value * 0.3048,
    in : (value) => value * 0.0254
}

const meterConverter = {
    km : (value) => value / 1000,
    m : (value) => value / 1,
    cm : (value) => value / 0.01,
    mm : (value) => value / 0.001,
    mi : (value) => value / 1609.34,
    yrd : (value) => value / 0.9144,
    ft : (value) => value / 0.3048,
    in : (value) => value / 0.0254
}

    $('#convert').on('click', convert);

    function convert(){
        let $inputDistance = $('#inputDistance').val();
        let $inputUnits = $('#inputUnits :selected').val();
        let $outputUnits = $('#outputUnits :selected').val();

        let distanceinMeters = converterToMeter[$inputUnits]($inputDistance);
        let convertedDistance = meterConverter[$outputUnits](distanceinMeters);

        $('#outputDistance').val(convertedDistance);
    }
}