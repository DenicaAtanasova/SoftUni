function Solve(personData, workoutsCount) {
    let caloriesFormula = {};

    caloriesFormula['m'] = function (weight, height, age) {
        return 66 + 13.8*weight + 5*height - 6.8*age
    };

    caloriesFormula['f'] = function (weight, height, age) {
        return 655 + 9.7*weight + 1.85*height - 4.7*age
    };

    let AFCalculator = function (workoutsCount) {
        if(workoutsCount < 1){
            return 1.2;
        } else if(workoutsCount < 3){
            return 1.375;
        } else if(workoutsCount < 6){
            return 1.55;
        } else if(workoutsCount < 8){
            return 1.725;
        } else {
            return 1.9;
        }
    };

    let gender = personData[0];
    let weight  = personData[1];
    let height = personData[2];
    let age = personData[3];

    let calories = caloriesFormula[gender](weight, height, age);
    let AF = AFCalculator(workoutsCount);

    let calorieIntake = Math.round(calories * AF);

    console.log(calorieIntake);
}

Solve(['m', 86, 185, 25], 3);