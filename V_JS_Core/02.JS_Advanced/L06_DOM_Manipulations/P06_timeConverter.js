function attachEventsListeners() {
    $('input[type=button]').click(function(e){
        let textInputElement = e.target.parentNode.children[1];
        let type = textInputElement.id;
        let value = textInputElement.value;
        
        let seconds = convertToSeconds(type, value);
        convertTime(seconds);
    })

    function convertToSeconds(type, value){
        switch (type) {
            case 'days':              
            return value * 86400;

            case 'hours':
            return value * 3600;

            case 'minutes':
            return value * 60;

            default:
            return value;
        }
    }

    function convertTime(seconds){
        $('#days').val(seconds / 86400);
        $('#hours').val(seconds / 3600);
        $('#minutes').val(seconds / 60);
        $('#seconds').val(seconds);
    }
}  