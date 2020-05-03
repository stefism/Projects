function attachEventsListeners() {
    let daysBtn = document.getElementById('daysBtn')
    let hoursBtn = document.getElementById('hoursBtn')
    let minutesBtn = document.getElementById('minutesBtn')
    let secondsBtn = document.getElementById('secondsBtn')

    let days = document.getElementById('days')
    let hours = document.getElementById('hours')
    let minutes = document.getElementById('minutes')
    let seconds = document.getElementById('seconds')

    daysBtn.addEventListener('click', calculateOnDaysBase)
    hoursBtn.addEventListener('click', calculateOnHourBase)
    minutesBtn.addEventListener('click', calcOnMinuteBase)
    secondsBtn.addEventListener('click', calcOnSecondBase)

    function calculateOnDaysBase() {
        days = days.value
        hours.value = days * 24
        minutes.value = days * 1440
        seconds.value = days * 86400
    }

    function calculateOnHourBase() {
        hours = hours.value
        days.value = hours / 24
        minutes.value = (hours / 24) * 1440
        seconds.value = (hours / 24) * 86400
    }

    function calcOnMinuteBase() {
        minutes = minutes.value
        days.value = minutes / 1440
        hours.value = (minutes / 1440) * 24
        seconds.value = (minutes / 1440) * 86400
    }

    function calcOnSecondBase() {
        seconds = seconds.value
        days.value = seconds / 86400
        hours.value = (seconds / 86400) * 24
        minutes.value = (seconds / 86400) * 1440
    }
}