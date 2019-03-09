function create(sentences){
    for (let item of sentences) {
        let $p = $('<p>').text(item).hide();

        $('<div>').on('click', ()=> $p.show())
                  .append($p)
                  .appendTo($('#content'));
    }
}