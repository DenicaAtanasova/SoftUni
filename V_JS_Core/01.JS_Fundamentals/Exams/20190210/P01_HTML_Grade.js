function solve(examPoints, completedHomework, totalHomework){
    let maxPoints = 100;
    let maxExamPoints = 400;
    let calculatedExamPoints = examPoints * (90 / maxExamPoints);
    
    let homeworkBonus = (completedHomework / totalHomework) * 10;

    let totalPoints = calculatedExamPoints + homeworkBonus;
    let grade;

    if(examPoints === maxExamPoints){
        grade = 6;
    } else{
        grade = 3 + 2 * (totalPoints - maxPoints / 5) / (maxPoints / 2);
        if(grade < 3){
            grade = 2;
        }

        if(grade > 6){
            grade = 6;
        }
    }


    console.log(grade.toFixed(2));
}

solve(200, 5, 5);