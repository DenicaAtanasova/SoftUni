function AddOrRemove(arr){
    let result = [];
    for (let i = 0; i < arr.length; i ++) {
        let operation = arr[i].split(' ');
        let command = operation[0];
        let num = Number(operation[1]);

        switch (command){
            case 'add':
                result.push(num);
                break;
            case 'remove':
                result.splice(num, 1);
                break;
        }
    }
    for (let num of result) {
        console.log(num);
    }
}
AddOrRemove(['add 3', 'add 5', 'add 7'])