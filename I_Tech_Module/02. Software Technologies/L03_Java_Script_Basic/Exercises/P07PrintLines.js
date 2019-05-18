function printLines(lines){
    for (let line of lines) {
        if (line != 'Stop') {
            console.log(line);
        } else{
            break;
        }
    }
}
printLines()