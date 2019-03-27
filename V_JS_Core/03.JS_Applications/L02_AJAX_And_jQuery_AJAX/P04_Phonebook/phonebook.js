function attachEvents(){
    let baseUrl = 'https://phonebook-nakov.firebaseio.com/phonebook.json';
    
    $('#btnLoad').on('click', downloadPhonebook);
       
    $('#btnCreate').on('click', createContact);

    function downloadPhonebook(){       
        $.get(baseUrl)
        .then((data)=>renderPhoneBook(data));
    };

    function renderPhoneBook(data){   
        $('#phonebook').empty();

        Object.entries(data)
            .forEach(entry => {
                let key = entry[0];
                let person = entry[1].person;
                let phone = entry[1].phone;

                $('#phonebook')
                    .append($('<li>')
                        .text(`${person}: ${phone}`)
                        .append($('<button>')
                            .text('DELETE')
                            .on('click', {param:key}, deleteEntry)
            )); 
        });       
    };

    function deleteEntry(event){
        let key = event.data.param;
        let deleteUrl = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
        
        $.ajax({
            method: 'DELETE',
            url: deleteUrl        
        })

        $(this).parent().remove()       
    };

    function createContact(){
        let contact = {
            person: $('#person').val(),
            phone: $('#phone').val()
        }

        $('#person').val('');
        $('#phone').val('');
        uploadPhoneBook(contact);
    };

    function uploadPhoneBook(contact){
        let data = JSON.stringify(contact);
        $.post(baseUrl, data);
    };
}