function solve(commands) {
    let num = 0;
    let numbers = [];

    for (let command of commands){
        num ++;
        switch (command) {
            case 'add':
                numbers.push(num);
                break;
            default:
                numbers.pop();
        }
    }

    console.log(numbers.length === 0 ? 'Empty' : numbers.join('\r\n'));
}

solve(['remove', 'remove', 'remove']);