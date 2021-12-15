function attachEventsListeners() {
    let measuresToMeters = {
        km: 1000,
        m: 1,
        cm: 0.01,
        mm: 0.001,
        mi: 1609.34,
        yrd: 0.9144,
        ft: 0.3048,
        in: 0.254
    }

    let inputUnits = document.getElementById('inputUnits');
    let outputUnits = document.getElementById('outputUnits');
    let convertButton = document.getElementById('convert');

    convertButton.addEventListener('click', () => {
        let from = inputUnits.options[inputUnits.selectedIndex].value;
        let to = outputUnits.options[outputUnits.selectedIndex].value;

        let input = document.getElementById('inputDistance');
        let output = document.getElementById('outputDistance');

        let result = ((measuresToMeters[from] * input.value) / measuresToMeters[to]).toFixed(2);
        output.value = result;
    });
}