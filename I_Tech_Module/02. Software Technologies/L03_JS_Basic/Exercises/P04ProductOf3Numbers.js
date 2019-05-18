function findTheSign(nums) {
    let count = 0;
    for (let i = 0; i < 3; i++) {
        if (nums[i] < 0) {
            count++;
        }
    }
    if (count % 2 === 0) {
        console.log('Positive');
    } else {
        console.log('Negative');
    }
}
findTheSign()