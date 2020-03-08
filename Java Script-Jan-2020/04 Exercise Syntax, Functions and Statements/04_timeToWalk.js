function timeToWalk(steps, stepsLength, speedPerKm){
    let distanceInMeters = steps * stepsLength;
    let minutesToRest = Math.floor(distanceInMeters / 500);
    let time = distanceInMeters / speedPerKm / 1000 * 60;
    let totalTime = Math.ceil((minutesToRest + time) * 60);
    
    let result = new Date(null, null, null, null, null, totalTime);

    console.log(result.toTimeString().split(' ')[0]);
}

timeToWalk(4000, 0.60, 5);