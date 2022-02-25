window.onload = forecast();

let allLocations = [];
let currLocationsInput = '';

const conditionSymbols = {
    'Sunny': '☀',
    'Partly sunny': '⛅',
    'Overcast': '☁',
    'Rain': '☂',
    'Degrees': '°'
}

function forecast() {
    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', manageForecast);
}

async function manageForecast() {
    try {
        if(allLocations.length == 0) {
            const responce = await fetch('http://localhost:3030/jsonstore/forecaster/locations');
            allLocations = await responce.json();
        }
        
        currLocationsInput = document.getElementById('location').value;
        let currLocationsCode = getCurrentLocationCode(allLocations, currLocationsInput);

        const [currForecast, threeDayForecast] = await Promise.all([
            getForecastForUserInputLocations(currLocationsCode),
            getThreeDayForecast(currLocationsCode)
        ]);
      
        displayForecast(currForecast);
        showThreeDayForecast(threeDayForecast);
    } catch (error) {
        
    }
}

async function getForecastForUserInputLocations(currLocationsCode) {  
    try {
        const responce = await fetch(`http://localhost:3030/jsonstore/forecaster/today/${currLocationsCode}`);
        let forecast = await responce.json();

        return forecast;
    } catch (error) {
        
    }
}

async function displayForecast(currForecast) {
    let currentElement = document.getElementById('current');

    let forecast = document.querySelector('#current > div.forecasts');
    if(forecast) forecast.remove();
    
    let forecastElement = document.getElementById('forecast');
    forecastElement.style.display = 'block';
    
    let forecastsDivElement = document.createElement('div');
    forecastsDivElement.classList.add('forecasts');

    let spanConditionSymbolElement = createSpanElement('condition symbol', conditionSymbols[currForecast.forecast.condition]);

    forecastsDivElement.appendChild(spanConditionSymbolElement);

    let conditionDataElement = createSpanElement('condition', '');
    
    let locationSpanElement = createSpanElement('forecast-data', currForecast.name);
    conditionDataElement.appendChild(locationSpanElement);

    let tempSpanElement = createSpanElement('forecast-data', `${currForecast.forecast.low + conditionSymbols.Degrees}/${currForecast.forecast.high + conditionSymbols.Degrees}`);
    conditionDataElement.appendChild(tempSpanElement);

    let weatherSpanElement = createSpanElement('forecast-data', currForecast.forecast.condition);
    conditionDataElement.appendChild(weatherSpanElement);

    forecastsDivElement.appendChild(conditionDataElement);

    currentElement.appendChild(forecastsDivElement);

}

function getCurrentLocationCode(allLocations, currLocationsInput) {
    let currLocations = allLocations.find(l => l.name == currLocationsInput);
    return currLocations.code;
}

async function getThreeDayForecast(currLocationCode) {
    try {
        let responce = await fetch(`http://localhost:3030/jsonstore/forecaster/upcoming/${currLocationCode}`);
        let forecast = responce.json();

        return forecast;
    } catch (error) {
        
    }
}

function showThreeDayForecast(forecast) { 
    let threeDayForecast = [...forecast.forecast];

    let upcomingDiv = document.getElementById('upcoming');

    let threeDaysOld = document.querySelector('#upcoming > div:nth-child(2)');
    if(threeDaysOld) threeDaysOld.remove();
    
    let forecastInfoDiv = document.createElement('div');

    threeDayForecast = threeDayForecast.map(f => {
        let upcomingSpan = createSpanElement('upcoming', '');

        let symbolSpan = createSpanElement('symbol', conditionSymbols[f.condition]);
        upcomingSpan.appendChild(symbolSpan);

        let tempSpanElement = createSpanElement('forecast-data', `${f.low + conditionSymbols.Degrees}/${f.high + conditionSymbols.Degrees}`);
        upcomingSpan.appendChild(tempSpanElement);

        let weatherSpanElement = createSpanElement('forecast-data', f.condition);
        upcomingSpan.appendChild(weatherSpanElement);

        return upcomingSpan;
    });

    threeDayForecast.forEach(f => forecastInfoDiv.appendChild(f));
    upcomingDiv.appendChild(forecastInfoDiv);
}

function createSpanElement(classes, textContent) {
    let element = document.createElement('span');
  
    classes.split(' ').forEach(c => element.classList.add(c));
    element.textContent = textContent;
    
    return element;
}