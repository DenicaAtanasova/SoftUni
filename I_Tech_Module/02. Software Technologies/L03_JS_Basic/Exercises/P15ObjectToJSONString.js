function objectToJSONString(arr) {
    let object = {};
    for (let i = 0; i < arr.length; i ++){
        let pair = arr[i].split(' -> ');
        if (isNaN(pair[1])) {
            object[pair[0]] = pair[1];
        } else {
            object[pair[0]] = +pair[1];
        }
    }
    let str = JSON.stringify(object);
    console.log(str);
}

objectToJSONString(['name -> Angel', 'surname -> Georgiev', 'age -> 20', 'grade -> 6.00', 'date -> 23/05/1995', 'town -> Sofia']);