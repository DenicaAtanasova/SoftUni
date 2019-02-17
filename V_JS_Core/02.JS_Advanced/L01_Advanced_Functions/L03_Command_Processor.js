function solve(input){
    let closure = (() => {
        let defaultString = '';
        return {
            append: (s) => defaultString += s,
            removeStart: (n) => defaultString = defaultString.slice(n),
            removeEnd: (n) => defaultString = defaultString.slice(0, defaultString.length - n),
            print: () => console.log(defaultString)          
        }
    })();

    input.forEach(inputString => {
        let [command, value] = inputString.split(' ');
        closure[command](value);
    });
};

solve(['append hello',
        'append again',
        'removeStart 3',
        'removeEnd 4',
        'print'])