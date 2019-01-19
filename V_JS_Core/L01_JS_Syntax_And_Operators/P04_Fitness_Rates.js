function Solve(day, service, time){
    let daysOfWeek = function (day) {
        return ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'].indexOf(day)
    };

    let weekDayService = {
        'Fitness': 5,
        'Sauna': 4,
        'Instructor': 10
    };

    if (daysOfWeek(day) <= 4) {
        if (time <= 15){
            console.log(weekDayService[service]);
        } else {
            console.log((weekDayService[service] + 2.5));
        }
    } else{
        console.log(Math.ceil(weekDayService[service] / 2) + weekDayService[service]);
    }
}

Solve('Monday', 'Sauna', 15.3);