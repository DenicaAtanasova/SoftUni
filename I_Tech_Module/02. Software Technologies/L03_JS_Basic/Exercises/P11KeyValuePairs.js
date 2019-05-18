function keyValuePairs(arr){
    let objects = {};
    let key;

    for(let i = 0; i < arr.length; i ++){
        let pair = arr[i].split(' ');
        if (pair.length > 1) {
            objects[pair[0]] = pair[1];
        } else {
            key = arr[i];
        }
    }

    console.log(objects[key] == undefined ? 'None' : objects[key]);
}

keyValuePairs(['key value', 'key eulav', 'test test', 'b']);