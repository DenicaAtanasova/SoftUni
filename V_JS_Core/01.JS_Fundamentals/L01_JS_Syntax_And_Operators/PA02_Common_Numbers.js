function Solve(arr1, arr2, arr3) {
    function onlyUnique(value, index, self) {
        return self.indexOf(value) === index;
    }

    let merged = [];
    merged.push(arr1);
    merged.push(arr2);
    merged.push(arr3);

    merged = [].concat.apply([], merged);

    let uniqueNums = merged.filter( onlyUnique ); // returns ['a', 1, 2, '1']

    let commonNums = [];
    let average = 0;

    for (let i = 0; i < uniqueNums.length; i++){
        if(arr1.includes(uniqueNums[i]) && arr2.includes(uniqueNums[i]) && arr3.includes(uniqueNums[i])){
            commonNums.push(uniqueNums[i]);
            average += uniqueNums[i];
        }
    }

    console.log(`The common elements are ${commonNums.sort().join(', ')}.`);

    average /= commonNums.length;
    console.log(`Average: ${average}.`);

    let median;
    let middleLength = commonNums.length / 2 | 0;
    if (commonNums.length % 2 === 0) {
        median = (commonNums[middleLength - 1] + commonNums[middleLength]) / 2;
    } else {
        median = commonNums[middleLength];
    }
    console.log(`Median: ${median}.`);
}

Solve([5, 6, 50, 10, 1, 2],
    [5, 4, 8, 50, 2, 10],
    [5, 2, 50]
);