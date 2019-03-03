function increment(selector) {
    console.log($(selector));

    let textarea = createElement('<textarea>', 'counter')
                   .val(0)
                   .attr('disabled', true);

    let incrementButton = createElement('<button>', 'btn')
                          .attr('id', 'incrementBtn')
                          .text('Increment')
                          .click(increment);

    let addButton = createElement('<button>', 'btn')
                    .attr('id', 'addBtn')
                    .text('Add')
                    .click(add);

    let ul = createElement('<ul>', 'results');
    
    $(selector)
        .append(textarea)
        .append(incrementButton)
        .append(addButton)
        .append(ul);


    function createElement(elementType, elementClass){
        return $(elementType).addClass(elementClass);
    }

    function increment(){
        let num = 1 + Number(textarea.val());
        textarea.val(num);
    }

    function add(){
        let li = createElement('<li>').text(textarea.val());
        ul.append(li);
    }
}