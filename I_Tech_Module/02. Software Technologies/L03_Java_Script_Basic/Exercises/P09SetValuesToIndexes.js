function setValues(nums) {
    let result = [];

    for (let i = 1; i < nums.length; i ++){
        let indexAndNum = nums[i].split(' - ');
        result[indexAndNum[0]] = indexAndNum[1];
    }
    for (let i = 0; i < nums[0]; i ++){
        if (result[i] == undefined){
            console.log('0');
        } else {
            console.log(result[i]);
        }
    }
}
setValues()