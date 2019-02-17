function composeChart(name, age, weight, height){

    const calculateBMI = (weight, height) => {
        return Math.round(weight / height ** 2);
    }

    const calculateStatus = (bmi) =>{
        if(bmi < 18.5){
            return 'underweight';
        } else if(bmi < 25){
            return 'normal';
        } else if(bmi < 30){
            return 'overweight';
        } else {
            return 'obese'
        }
    }

    const bmi = calculateBMI(weight, height/100);

    let personChart = {
        name,
        personalInfo: {
            age,
            weight,
            height,
        },
        BMI: bmi,
        status: calculateStatus(bmi)
    }

    if(personChart.status === 'obese'){
        personChart.recommendation = 'admission required';
    }

    return personChart
}

console.log(composeChart('Honey Boo Boo', 9, 57, 137));
