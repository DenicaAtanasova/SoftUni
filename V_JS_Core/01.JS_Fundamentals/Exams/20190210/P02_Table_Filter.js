function solve(table, command){

    let headers = table[0];
    table.splice(0, 1);
    let commandArgs = command.split(' ');

    switch (commandArgs[0]) {
        case 'hide':
        hide(commandArgs[1]);
        break;
        case 'sort':
        sort(commandArgs[1]);
        break;
        case 'filter':        
        filter(commandArgs[1], commandArgs[2]);
    }

    function hide(header){
        let headerIndex = headers.indexOf(header);
        headers.splice(headerIndex, 1);

        for (let i = 0; i < table.length; i++) {
            table[i].splice(headerIndex, 1);
        }

        console.log(headers.join(' | '));
        console.log(table.map(r => r.join(' | ')).join('\n'));
    }
    
    function sort(header){
        let headerIndex = headers.indexOf(header);
        table.sort((a, b) => a[headerIndex].localeCompare(b[headerIndex]));

        console.log(headers.join(' | '));
        console.log(table.map(r => r.join(' | ')).join('\n'));
    }

    function filter(header, value){
        let headerIndex = headers.indexOf(header);

        let searchedIndex = [];
        for (let i = 0; i < table.length; i++) {
            if(table[i][headerIndex] === value){
                searchedIndex.push(i);
            }
        }

        console.log(headers.join(' | '));
        
        if(searchedIndex.length > 0){
            searchedIndex.forEach(index =>{
                console.log(table[index].join(' | '));
            })
        }
    }
}

solve([['A', 'B', 'C', 'D'],
['a', 'a', 'a', 'a'],
['b', 'c', 'a', 'b'],
['c', 'a', 'c', 'c']],
'filter B z'
)