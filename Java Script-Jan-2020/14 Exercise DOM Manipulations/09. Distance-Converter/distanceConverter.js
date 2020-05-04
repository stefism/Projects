function attachEventsListeners() {
    let unitsToMeters = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.0254
    }

    let inputDistance = document.getElementById('inputDistance')
    let outputDistance = document.getElementById('outputDistance')

    let inputUnits = document.getElementById('inputUnits')
    let outputUnits = document.getElementById('outputUnits')

    let convertBtn = document.getElementById('convert')
    convertBtn.addEventListener('click', convert)

    function convert() {
        let from = inputUnits.value
        let to = outputUnits.value
        let distanceFrom = +inputDistance.value
        let distanceTo = (distanceFrom * unitsToMeters[from]) / unitsToMeters[to]
        outputDistance.value = distanceTo
    }
}