function solve(input){
    
    let tableData = JSON.parse(input);
    let output = '<table>\n' +
                 '  <tr><th>name</th><th>score</th></tr>\n';

    tableData.forEach(element => {        
        output += `  <tr><td>${htmlEntities(element.name)}</td><td>${element.score}</td></tr>\n`;
    });
    
    output += '</table>';

    console.log(output);

    function htmlEntities(str) {
        return String(str).replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/"/g, '&quot;').replace(/'/g,'&#39;');
    }
}
solve('[{"name":"Pencho Penchev","score":0}]');