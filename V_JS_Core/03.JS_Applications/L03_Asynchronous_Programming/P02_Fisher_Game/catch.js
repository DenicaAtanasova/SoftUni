function attachEvents(){
    const baseUrl = 'https://baas.kinvey.com/';
    const appKey = 'kid_rJJMrDjdN/';
    const endPoint = 'biggestCatches';
    const username = 'denica';
    const password = '159357';
    const headers = {
        'Authorization' : `Basic ${btoa(username + ':' + password)}`,
        'Content-Type' : 'application/json'
    };   
    let url = baseUrl + 'appdata/' + appKey + endPoint;

    $('.load').on('click', loadCatches);
    
    async function loadCatches(){

        let catches = await $.ajax({
            method: 'GET',
            url,
            headers
        })
   
        $('#catches').empty();

        for (let catchInfo of catches) {
            let $div = $(`
                <div class="catch" data-id="${catchInfo._id}">
                    <label>Angler</label>
                    <input type="text" class="angler" value="${catchInfo.angler}"/>
                    <label>Weight</label>
                    <input type="number" class="weight" value="${catchInfo.weight}"/>
                    <label>Species</label>
                    <input type="text" class="species" value="${catchInfo.species}"/>
                    <label>Location</label>
                    <input type="text" class="location" value="${catchInfo.location}"/>
                    <label>Bait</label>
                    <input type="text" class="bait" value="${catchInfo.bait}"/>
                    <label>Capture Time</label>
                    <input type="number" class="captureTime" value="${catchInfo.captureTime}"/>
                </div>`);

            $div
            .append($('<button>')
                .text('Update')
                .addClass('update')
                .on('click', updateCatch)) 
            .append($('<button>')
                .text('Delete')
                .addClass('delete')
                .on('click', deleteCatch));

            $('#catches').append($div);
        }
    }

    $('.add').on('click', addCatch);
    
    async function addCatch(){
        let currentCatch = {
            angler : $('#addForm .angler').val(),
            weight : +$('#addForm .weight').val(),
            species : $('#addForm .species').val(),
            location : $('#addForm .location').val(),
            bait : $('#addForm .bait').val(),
            captureTime : +$('#addForm .captureTime').val()
        };

        await $.ajax({
            method: 'POST',
            url,
            headers,
            data: JSON.stringify(currentCatch)
        })
        
        loadCatches();
    }

    $('.update').on('click', updateCatch);
    
    async function updateCatch(){
        let catchId = $(this).parent().data('id');
        
        let angler = $(this).parent().find('.angler').val();
        let weight = +$(this).parent().find('.weight').val();
        let species = $(this).parent().find('.species').val();
        let location = $(this).parent().find('.location').val();
        let bait = $(this).parent().find('.bait').val();
        let captureTime = +$(this).parent().find('.captureTime').val();

        let updatedCatch = {
            angler,
            weight,
            species,
            location,
            bait,
            captureTime
        };

        await $.ajax({
            method:'PUT',
            url: url + '/' + catchId,
            headers,
            data: JSON.stringify(updatedCatch) 
        })
        loadCatches();
    }

    $('.delete').on('click', deleteCatch);
    
    async function deleteCatch(){
        
        let catchId = $(this).parent().data('id');

        await $.ajax({
            method:'DELETE',
            url: url + '/' + catchId,
            headers
        })

        loadCatches();
    }
}