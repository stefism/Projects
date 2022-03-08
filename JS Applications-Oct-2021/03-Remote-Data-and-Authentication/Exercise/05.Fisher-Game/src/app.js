const url = 'http://localhost:3030/data/catches';

const userEmail = sessionStorage.getItem('email');
const userId = sessionStorage.getItem('userId');
const userToken = sessionStorage.getItem('authToken');

const catches = document.getElementById('catches');

const header = document.getElementById('header');
header.textContent = `${header.textContent}  <${userEmail}>`;

const loadBtn = document.querySelector('main aside button');
loadBtn.addEventListener('click', showCatchesOnDom);

const loginBtn = document.getElementById('login');

const logoutBtn = document.getElementById('logout');
logoutBtn.addEventListener('click', onLogout);

const addBtn = document.getElementById('addBtn');

if(userId != undefined) {
    addBtn.disabled = false;
    loginBtn.style.display = 'none';
    logoutBtn.style.display = 'block';
}

async function onLogout() {
    await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': userToken
        }
    });

    sessionStorage.clear();
}

async function loadCatches() {
    const responce = await fetch(url);
    return await responce.json();
}

async function showCatchesOnDom() {
    const result = await loadCatches();
    let allCatches = result.map(createCatchDivElement);
    catches.replaceChildren(...allCatches);
}

function createCatchDivElement(currCatch) {
    let isButtonDisabled = '';

    if(currCatch._ownerId != userId) {
        isButtonDisabled = 'disabled';
    }

    let divElement = document.createElement('div');
    divElement.innerHTML = `
    <label id="${currCatch._ownerId}">Angler</label>
    <input type="text" class="angler" value="${currCatch.angler}"/>
    <label>Weight</label>
    <input type="number" class="weight" value="${currCatch.weight}"/>
    <label>Species</label>
    <input type="text" class="species" value="${currCatch.species}"/>
    <label>Location</label>
    <input type="text" class="location" value="${currCatch.location}"/>
    <label>Bait</label>
    <input type="text" class="bait" value="${currCatch.bait}"/>
    <label>Capture Time</label>
    <input type="number" class="captureTime" value="${currCatch.captureTime}"/>
    <button ${isButtonDisabled} class="add">Update</button>
    <button ${isButtonDisabled} class="delete">Delete</button>`;

    return divElement;
}