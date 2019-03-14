function solve(obj){
    if(obj.handsShaking){
        obj.bloodAlcoholLevel += obj.experience * obj.weight * 0.1;
        obj.handsShaking = false;
    }

    return obj
}

console.log(solve({ weight: 95,
    experience: 3,
    bloodAlcoholLevel: 0,
    handsShaking: false }
))
