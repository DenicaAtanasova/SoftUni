function solve(input){
    let pattern = /(<\w+>).+(<\/\w+>)/;

    let match;

    for (let i = 0; i < input.length; i++) {
        if(!pattern.test(input)){
            input[i] = '';
        }
        while (match = pattern.exec(input[i])) {
            if(match[1] === match[2][0] + match[2].substr(2, match[2].length)){
                input[i] = input[i].replace(match[1], '');
                input[i] = input[i].replace(match[2], '');
            } else{
                input[i] = '';
            }
        }
    }

    input = input.filter(x => x && !x.includes('>') && !x.includes('<')). join(' ');
    console.log(input);
}                                 

solve(['<div></p>This is</div>',
'<div><a>perfectly</a></div>',
'<divs><p>valid</p></divs>',
'<div><p>This</div></p>',
'<div><p>is not</p><div>']
);