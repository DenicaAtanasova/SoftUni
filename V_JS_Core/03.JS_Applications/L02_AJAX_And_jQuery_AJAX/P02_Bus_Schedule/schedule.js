function solve() {

    let name = 'Depot';
    let next = 'depot';
 
    function depart(){
        let url = `https://judgetests.firebaseio.com/schedule/${next}.json`;

        $.ajax({
            method: 'GET',
            url,
            success: updateInfo
        })
        
        $('#depart').attr('disabled', true);
        $('#arrive').attr('disabled', false);     
    };

    function arrive(){
        $('.info').text(`Arriving at ${name}`);
        $('#depart').attr('disabled', false);
        $('#arrive').attr('disabled', true);       
    };

    function updateInfo(data){
        name = data.name;
        next = data.next;
        $('.info').text(`Next stop ${name}`);
    }

    return {
      depart,
      arrive
    };
  }

  let result = solve();