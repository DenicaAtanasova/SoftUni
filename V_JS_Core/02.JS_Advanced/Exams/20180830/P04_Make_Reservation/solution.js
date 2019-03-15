function makeReservation(selector){

    let personalInfo = {};

    $('#submit').click(function () { 
        personalInfo.fullname = $('#fullName').val();
        personalInfo.email = $('#email').val();
        personalInfo.phoneNumber = $('#phoneNumber').val();
        personalInfo.address = $('#address').val();
        personalInfo.postalCode = $('#postalCode').val();

        if (personalInfo.fullname && personalInfo.email) {
            $('#infoPreview')
            .append($('<li>').text(`Name: ${personalInfo.fullname}`))
            .append($('<li>').text(`E-mail: ${personalInfo.email}`))
            .append($('<li>').text(`Phone: ${personalInfo.phoneNumber}`))
            .append($('<li>').text(`Address: ${personalInfo.address}`))
            .append($('<li>').text(`Postal Code: ${personalInfo.postalCode}`));

            $('.inputLabel input').val('');

            $(this).attr("disabled", true);
            $('#edit').attr("disabled", false);
            $('#continue').attr("disabled", false);
        } 
    });

    $('#edit').click(function(){

        $('#fullName').val(personalInfo.fullname);
        $('#email').val(personalInfo.email);
        $('#phoneNumber').val(personalInfo.phoneNumber);
        $('#address').val(personalInfo.address);
        $('#postalCode').val(personalInfo.postalCode);

        $('li').remove();

        $('#submit').attr("disabled", false);
        $(this).attr("disabled", true);
        $('#continue').attr("disabled", true);
    });

    $('#continue').click(function(){

        let $selectElement = $('<select>')
                .attr('id', 'paymentOptions')
                .addClass('custom-select')
                .append($('<option>').attr('selected', '')
                                     .attr('disabled', '')
                                     .attr('hidden', '')
                                     .text('Choose'))
                .append($('<option>').attr('value', 'creditCard').text('Credt Card'))
                .append($('<option>').attr('value', 'bankTransfer').text('Bank Transfer'));

        $(selector)
                .append($('<h2>').text('Payment details'))
                .append($selectElement)
                .append($('<div>').attr('id', 'extraDetails'));

        $('#submit').attr("disabled", true);
        $('#edit').attr("disabled", true);
        $(this).attr("disabled", true);
    });

    $(selector).change(function() {
        let selection = $(this).find('option:selected').val();
        
        if (selection === 'creditCard') {
            $('#extraDetails')
                .empty()
                .append($('<div>')
                    .addClass('inputLabel')
                    .text('Card Number')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<div>')
                    .addClass('inputLabel')
                    .text('Expiration Date')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<div>')
                    .addClass('inputLabel')
                    .text('Security Numbers')
                    .append($('<input>')))
                .append($('<br>'))
                .append($('<button>').attr('id', 'checkOut').text('Check Out').click(finishReservation))
        } else {
            $('#extraDetails')
                .empty()
                .append($('<p>')
                        .html('You have 48 hours to transfer the amount to:<br>IBAN: GR96 0810 0010 0000 0123 4567 890'))
                .append($('<button>').attr('id', 'checkOut').text('Check Out').click(finishReservation))
        }
    });

    function finishReservation(){
        $('#wrapper')
            .empty()
            .append($('<h4>').text('Thank you for your reservation!'))
    }
}