function solve() {
    let resultElement = document.getElementById('result');
    
	let mat1Element = document.getElementById('mat1');
	let mat2Element = document.getElementById('mat2');

	let mat1 = JSON.parse(mat1Element.value);
	let mat2 = JSON.parse(mat2Element.value);

    mat2 = transpose(mat2);

    appendResult();
    
    function transpose(array){
        return array[0].map((col, i) => array.map(row => row[i]));
    }

    function appendResult(){
        for(let mat1Row = 0; mat1Row < mat1.length; mat1Row++){

            let result = multiplyRow(mat1Row).join(', ');
            let pElement = document.createElement('p');

            pElement.textContent = result;

            resultElement.appendChild(pElement);
        }       
    }

    function multiplyRow(mat1Row){
        let multipliedRow = [];

        for(let mat2Col = 0; mat2Col < mat1.length; mat2Col++){          
            let number = 0;

            for(let mat2Row = 0; mat2Row < mat2.length; mat2Row++){               
                number += mat1[mat1Row][mat2Row] * mat2[mat2Row][mat2Col];                    
            }
            multipliedRow.push(number);
        }

        return multipliedRow;
    }
}