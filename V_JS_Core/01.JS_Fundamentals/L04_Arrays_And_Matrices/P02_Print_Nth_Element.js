function solve(arr) {
    let step = arr.pop();

    arr.filter((x, index) => index % step === 0).forEach(x => console.log(x));
}

solve(['5', '20', '31', '4', '20', '2']);