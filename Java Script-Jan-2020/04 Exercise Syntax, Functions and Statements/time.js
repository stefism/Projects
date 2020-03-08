function timeToWalk(steps, stepsLength, speedPerKm){
    let distanceInMeters = steps * stepsLength;
    let minutesToRest = Math.floor(distanceInMeters / 500);
    let timeInSeconds = (distanceInMeters / (speedPerKm * 1000)) * 3600;

    let minutes = Math.floor((timeInSeconds / 60) + minutesToRest);
    let seconds = Math.round(timeInSeconds % 60);
    seconds = seconds == 60 ? 0 : seconds;

    if (minutes < 60) {
        console.log(`00:${minutes}:${seconds < 10 ? `0${seconds}` : seconds}`);
    } else {
        let hours = minutes / 60;
        let min = minutes % 60;

        if (hours < 10) {
            console.log(`0${Math.floor(hours)}:${min}:${seconds < 10 ? `0${seconds}` : seconds}`);
        } else {
            console.log(`${Math.floor(hours)}:${min}:${seconds < 10 ? `0${seconds}` : seconds}`);
        }       
    }
}

timeToWalk(2564, 0.70, 5.5);
timeToWalk(41000, 1, 5);