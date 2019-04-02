function solve(){
    let appKey = 'kid_BJXTsSi-e/';
    //let appSecret = '447b8e7046f048039d95610c1b039390';
    let username = 'guest';
    let password = 'guest';
    let headers = {
        'Authorization' : `Basic ${btoa(username + ':' + password)}`,
        'Content-Type' : 'application/json'
    };

    let endPoint = 'students';   
    let baseUrl = 'https://baas.kinvey.com/';

    let url = baseUrl + 'appdata/' + appKey + endPoint;
    
    async function loadStudents(){       

        let students = await $.ajax({
            method:'GET',
            url,
            headers   
        });
        
        for(let student of students.sort((a,b) => a.ID - b.ID)){
            let $tr = $(`
                <tr>
                    <td>${student.ID}</td>
                    <td>${student.FirstName}</td>
                    <td>${student.LastName}</td>
                    <td>${student.FacultyNumber}</td>
                    <td>${student.Grade}</td>
                </tr>`);  

            $('#results ').append($tr);
        }      
    }

    async function createStudent(id, firstName, lastName, facultyNumber, grade){
        let student = {
            ID : id,
            FirstName : firstName,
            LastName : lastName,
            FacultyNumber : facultyNumber,
            Grade : grade
        };   
        
        await $.ajax({
            method: 'POST',
            url,
            headers,
            data: JSON.stringify(student)
        });

        loadStudents();
    }
}

solve();