function addDestination(){

    let city = $('.inputData')[0].value;
    let country = $('.inputData')[1].value;

    if(city && country){       
        let destination = `${city}, ${country}`;
        let season = $('#seasons :selected').text();

        $('<tr>')
        .append($('<td>').text(destination))
        .append($('<td>').text(season))
        .appendTo($('#destinationsList'));
    
        $(`#${season.toLowerCase()}`).val( function(i, val) {
            return ++val;
        });
        $('#seasons').prop('selectedIndex',0);
        $('.inputData').val('');
    }
}