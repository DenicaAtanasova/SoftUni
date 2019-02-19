function solve(input){
    
    let headings = input.shift()
                        .split('|')
                        .filter(x => x)
                        .map(x => x.trim());

    let towns = [];

    for (let i = 0; i < input.length; i++) {

        let townArgs = input[i].split('|')
                            .filter(x => x)
                            .map(x => x.trim());
        let currentTown = {
            [headings[0]]: townArgs[0],
            [headings[1]]: +townArgs[1],
            [headings[2]]: +townArgs[2],
        }  
        
        towns.push(currentTown);
    }
    console.log(JSON.stringify(towns));
    
}

solve(['| Town | Latitude | Longitude |',
'| Veliko Turnovo | 43.0757 | 25.6172 |',
'| Monatevideo | 34.50 | 56.11 |']
);