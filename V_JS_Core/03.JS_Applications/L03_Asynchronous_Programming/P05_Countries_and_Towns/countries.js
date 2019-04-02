function solution(){
    let appKey = 'kid_S1yOtmktN/';
    let username = 'User';
    let password = '123456';
    let headers = {
        'Authorization' : `Basic ${btoa(username + ':' + password)}`,
        'Content-Type' : 'application/json'
    };

    let endPoint = 'Countries';   
    let baseUrl = 'https://baas.kinvey.com/';

    $('#load').on('click', loadCountries);
    $('#add').on('click', addTown);

    async function loadCountries(){
        let url = baseUrl + 'appdata/' + appKey + endPoint; 

        let countries = await fetch(url, {headers})
             .then(res => res.json());
        $('#Countries-forms').empty();
        for(let country of countries){
            let $fieldset = $(`<fieldset data-id=${country._id}></fieldset>`)
                .append($('<legend>').text(`${country.name}`));

            let $form = $('<form>').addClass("country-from").append($fieldset);
                
            for(let town of country.towns){                   
                let $div =`
                    <div class="pairContainer">
                        <label class="town-name">Town name:</label>
                        <input type="text" class="town-name" value=${town}>
                        <button type="button" class="edit">Edit</button>
                        <button type="button" class="delete">Delete</button>
                    </div>`;
                $fieldset.append($div);
            }
            ($form).find('.edit').each((idx, btn) =>{                               
                $(btn).on('click', {id: country._id, town: country.towns[idx]}, editTown)
            });

            ($form).find('.delete').each((idx, btn) =>{                               
                $(btn).on('click', {id: country._id, town: country.towns[idx]}, deleteTown)
            });

            $('#Countries-forms').append($form);
        }      
    }

    async function addTown(){
        let url = baseUrl + 'appdata/' + appKey + endPoint; 

        let town = $('#town').val();
        let country = $('#country').val();

        if(town.length < 3 && country.length < 3){
            alert('Town name and Country name must be at least 3 characters long!');
        } else{
            let countries = await fetch(url, {headers})
            .then(res => res.json());

            let updatedCountry = {
                name : country,
                towns : []
            }
                    
            let method = 'POST';

            let doTownExist = false;
            if (countries.some(c => c.name === country)) {
                let currentCountry = countries.filter(c => c.name === country)[0];
                if(currentCountry.towns.includes(town)){
                    doTownExist = true;   
                    alert(`Town: ${town}! already exists!`);
                }

                let id = currentCountry._id;
                method = 'PUT';
                url = url + '/' + id;
                updatedCountry.towns = currentCountry.towns;
            }

            updatedCountry.towns.push(town)

            if (!doTownExist) {           
                let data = {
                    headers,
                    method,
                    body: JSON.stringify(updatedCountry)
                };

                await fetch(url, data);

                alert(`Successfuly added town: ${town}!`);

            }
            $('#town').val('');
            $('#country').val('');   
            loadCountries();
        }
    }

    async function deleteTown(event){
        let url = baseUrl + 'appdata/' + appKey + endPoint + '/' + event.data.id;
        let country = await fetch(url, {headers})
             .then(res => res.json());

        let index = country.towns.indexOf(event.data.town);
        country.towns.splice(index, 1);

        if(country.towns.length === 0){
            let method = 'DELETE';
            let data = {
            headers,
            method
            };

            await fetch(url, data);
        } else {
            let method = 'PUT';
            let data = {
            headers,
            method,
            body: JSON.stringify(country)
        };

        await fetch(url, data);
        }       

        alert(`Successfuly deleted town: ${event.data.town}!`);    
           
        loadCountries();  
    }

    async function editTown(event){
        let url = baseUrl + 'appdata/' + appKey + endPoint+ '/' + event.data.id;
        let country = await fetch(url, {headers})
             .then(res => res.json());

        let updateTown = $(this).parent().find('input.town-name').val();
        let index = country.towns.indexOf(event.data.town);
        country.towns.splice(index, 1, updateTown);

        let method = 'PUT';
        let data = {
            headers,
            method,
            body: JSON.stringify(country)
        };

        await fetch(url, data);

        loadCountries();
        alert(`Successfuly edited town: ${updateTown}!`);
    }
}