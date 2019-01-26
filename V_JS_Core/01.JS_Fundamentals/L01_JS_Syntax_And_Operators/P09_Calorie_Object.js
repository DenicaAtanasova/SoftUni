function Solve(input) {
    let caloriesInfo = {};

    for (let i = 0; i < input.length; i += 2){
        let foodName = input[i];
        caloriesInfo[foodName] = Number(input[i + 1]);
    }

    console.log(caloriesInfo);
}

Solve(['Yogurt', 48, 'Rise', 138, 'Apple', 52]);