let nextBusStop = 'depot';
let currBusName = '';

function solve() {
    let departButton = document.getElementById('depart');
    let arriveButton = document.getElementById('arrive');
    let info = document.getElementById('info');

    function depart() {
        departButton.disabled = true;
        arriveButton.disabled = false;

        let url = `http://localhost:3030/jsonstore/bus/schedule/${nextBusStop}`;

        getNextStop(url, info);
    }

    function arrive() {
        departButton.disabled = false;
        arriveButton.disabled = true;

        info.textContent = `Arriving at ${currBusName}`;
    }

    return {
        depart,
        arrive
    };
}

async function getNextStop(url, info) {
    try {
        let responce = await fetch(url);
        let data = await responce.json();
        info.textContent = `Next stop ${data.name}`;
        currBusName = data.name;
        nextBusStop = data.next;
    } catch (error) {
        
    }
}

let result = solve();