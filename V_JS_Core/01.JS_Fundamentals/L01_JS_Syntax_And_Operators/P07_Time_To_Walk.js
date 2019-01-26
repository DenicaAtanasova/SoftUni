function Solve(steps, footprintSize, speed){
    let distance = steps * (footprintSize / 1000);

    let minutesToAdd = (distance / 0.5) | 0;
    let TotalTime = distance / speed + (minutesToAdd/60);
    let hours = ('0' + (TotalTime | 0)).slice(-2);
    let minutes = ('0' + ((TotalTime % 1 * 60) | 0)).slice(-2);

    let seconds = ('0' + (Math.round(((TotalTime % 1 * 60) % 1) * 60))).slice(-2);

    console.log(`${hours}:${minutes}:${seconds}`);
}

Solve(2564, 0.7, 5.5);