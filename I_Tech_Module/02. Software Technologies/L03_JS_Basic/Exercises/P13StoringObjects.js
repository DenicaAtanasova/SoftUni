function  storingObjects(arr) {
    let students = [];

    for (let i = 0; i < arr.length; i ++) {
        let input = arr[i].split(' -> ');
        let student = {};
        student.name = input[0];
        student.age = input[1];
        student.grade = input[2];
        students.push(student);
    }
    for (let student of students){
        console.log('Name: ' + `${student.name}`)
        console.log('Age: ' + `${student.age}`)
        console.log('Grade: ' + `${student.grade}`)
    }
}

storingObjects(['Pesho -> 13 -> 6.00', 'Ivan -> 12 -> 4.90'])