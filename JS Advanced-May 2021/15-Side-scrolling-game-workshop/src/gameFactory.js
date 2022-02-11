function gameFactory() {
    let getState = gameStateFactory();
    let state = getState();

    let startScreen = document.querySelector('.start-screen');
    let playScreen = document.querySelector('.play-screen');  
    
    let wizardElement = createWizard(state.wizard.x, state.wizard.y);
    playScreen.appendChild(wizardElement);

    let factory = {
        startScreen,
        playScreen,
        wizardElement
    };

    return factory;
}

function createWizard(posX, posY) {
    let wizardElement = document.createElement('div');
    wizardElement.classList.add('wizard');
    wizardElement.style.top = posY + 'px';
    wizardElement.style.left = posX + 'px';

    return wizardElement;
}