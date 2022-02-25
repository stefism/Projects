let busesUlElement = document.getElementById('buses');
let stopName = document.getElementById('stopName');

async function getInfo() {
	stopName.textContent = 'Loading ...'
	let stopId = document.getElementById('stopId').value;

	try {
		const responce = await fetch(`http://localhost:3030/jsonstore/bus/businfo/${stopId}`);
		
		if(responce.status != 200) {
			throw new Error('Stop Id not found.');
		}
		
		const data = await responce.json();
		showBusStop(data)
	} catch (error) {
		showError(error);
	}
}

function showBusStop(data) {
	removeOldStops();
	stopName.textContent = data.name;
	
	for (const key in data.buses) {
		let li = document.createElement('li');
		li.textContent = `Bus ${key} arrives in ${data.buses[key]} minutes`;

		busesUlElement.appendChild(li);
	}
}

function showError(error) {
	removeOldStops();
	stopName.textContent = 'Error: ' + error.message;
}

function removeOldStops() {
	let liItems = Array.from(document.querySelectorAll('#buses li'));
	liItems.forEach(e => e.remove());
}