function attachEventsListeners() {
    let inputs = document.querySelector('main');

    inputs.addEventListener('click', (e) => {
        if (e.target.type == 'button') {
            let currentDiv = e.target.parentNode;
            let inputValue = currentDiv.querySelector('input').value;
            let buttonId = currentDiv.querySelectorAll('input')[1].id;

            convertTimes(buttonId, inputValue);
        }
    });

    function convertTimes(buttonId, inputValue) {
        let daysField = document.getElementById('days');
        let hoursField = document.getElementById('hours');
        let minutesField = document.getElementById('minutes');
        let secondsField = document.getElementById('seconds');

        switch (buttonId) {
            case 'daysBtn':
                let hours = inputValue * 24;
                let minutes = hours * 60;
                let seconds = minutes * 60;

                hoursField.value = hours;
                minutesField.value = minutes;
                secondsField.value = seconds;
                break;

            case 'hoursBtn':
                let days = inputValue / 24;
                let minutesFromHours = inputValue * 60;
                let secondsFromHours = minutesFromHours * 60;

                daysField.value = days;
                minutesField.value = minutesFromHours;
                secondsField.value = secondsFromHours;
                break;

            case 'minutesBtn':
                let hoursFromMinutes = inputValue / 60;
                let days2 = hoursFromMinutes / 24;
                let secondsFromMinutes = inputValue * 60;

                daysField.value = days2;
                hoursField.value = hoursFromMinutes;
                secondsField.value = secondsFromMinutes;
                break;

            case 'secondsBtn':
                let minutesFromSeconds = inputValue / 60;
                let hoursFromSeconds = minutesFromSeconds / 60;
                let daysFromSeconds = hoursFromSeconds / 24;

                minutesField.value = minutesFromSeconds;
                hoursField.value = hoursFromSeconds;
                daysField.value = daysFromSeconds;
                break;

            default:
                break;
        }
    }
}