function keyValuePairs(arr){
    let objects = {};
    let key;

    for(let i = 0; i < arr.length; i ++){
        let pair = arr[i].split(' ');
        if (pair.length > 1) {
            if (pair[0] in objects){
                objects[pair[0]].push(pair[1]);
            } else {
                objects[pair[0]] = [pair[1]];
            }
        } else {
            key = arr[i];
        }
    }
    if (objects[key] == undefined){
        console.log('None')
    } else {
        for (let obj of objects[key]) {
            console.log(`${obj}`);
        }
    }
}

keyValuePairs(['key value', 'key eulav', 'test test', 'p']);