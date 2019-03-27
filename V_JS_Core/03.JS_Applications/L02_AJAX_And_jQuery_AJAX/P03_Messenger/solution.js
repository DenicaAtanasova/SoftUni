function attachEvents(){
    const baseUrl = 'https://messenger-570d0.firebaseio.com/messages.json';
    $("#submit").click(submitmessage);
    $("#refresh").click(refresh);   

    function submitmessage(){
        let message = {
            author: $('#author').val(),
            content: $('#content').val(),
            timestamp: Date.now()
        }
        
        $.ajax({
            method:'POST',
            url: baseUrl,
            data: JSON.stringify(message),
            success: log
        })
    }

    function refresh(){
        $.ajax({
            method:'GET',
            url: baseUrl,
            success: logMessages
        })
    }

    function log(message){
        console.log(message);       
    }

    function logMessages(data){
        let refreshedLog = []
        Object.entries(data)
        .map(msg => msg[1])
        .forEach(msg =>{
            let message = `${msg.author}: ${msg.content}`;
            refreshedLog.push(message);        
        });      

        $('#messages')
            .text(refreshedLog
                .sort((a,b) => a.timestamp - b.timestamp)
                .join('\n'));
    }
}