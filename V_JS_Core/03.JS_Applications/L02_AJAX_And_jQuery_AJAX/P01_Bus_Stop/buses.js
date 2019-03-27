function getInfo(){
    let $stopId = $('#stopId').val();

    let url = `https://judgetests.firebaseio.com/businfo/${$stopId}.json`

    $.ajax({
        method:'GET',
        url,
        success: showBusStopInfo,
        error: showError 
    })

    function showBusStopInfo(data){ 
        $('#buses').empty();
         
        $("#stopName").text(data.name)  
        Object.entries(data.buses).forEach(bus =>{
            let busId = bus[0];
            let time = bus[1];
            let busInfo = `Bus ${busId} arrives in ${time} minutes`;

            $('#buses')
            .append($('<li>').text(busInfo))
        });
    }

    function showError(){
        $("#stopName").text('Error');
        $('#buses').empty();
    }
}