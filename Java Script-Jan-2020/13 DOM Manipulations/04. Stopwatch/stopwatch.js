function stopwatch() {
    let watch = document.getElementById('time')
    let startBtn = document.getElementById('startBtn')
    let stopBtn = document.getElementById('stopBtn')
    let [seconds, minutes] = [0, 0]
    let timeout

    startBtn.addEventListener('click', timer)
    stopBtn.addEventListener('click', clearTimer)

    function add() {
        seconds++
        if (seconds >= 60) {
            seconds = 0
            minutes++
        }

        watch.textContent = (minutes ? (minutes > 9 ? minutes : "0" + minutes) : "00")
            + ":" + (seconds > 9 ? seconds : "0" + seconds)

    }

    function timer() {
        watch.textContent = "00:00"
        startBtn.disabled = true
        stopBtn.disabled = false
        timeout = setInterval(add, 1000)
    }

    function clearTimer(){
        startBtn.disabled = false
        stopBtn.disabled = true
        clearInterval(timeout)
        seconds = 0
        minutes = 0
    }
}