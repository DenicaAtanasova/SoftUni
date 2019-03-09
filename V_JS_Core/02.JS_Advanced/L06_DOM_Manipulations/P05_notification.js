function notify(message) {
    $('#notification').css('display', 'block');
    $('#notification').text(message);

    setTimeout(() => {
        $('#notification').hide();
    }, 2000);
}