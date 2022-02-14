function gameFactory() {
    let globalState = state;

    let startScreen = document.querySelector('.start-screen');
    let playScreen = document.querySelector('.play-screen');  
    let scoreScreen = document.querySelector('.score-screen');  
    
    let wizardElement = createWizard(globalState.wizard.x, globalState.wizard.y);
    playScreen.appendChild(wizardElement);

    let factory = {
        startScreen,
        playScreen,
        scoreScreen,
        wizardElement,
        createBug: () => {
            let bugElement = document.createElement('div');
            bugElement.classList.add('bug');
            bugElement.style.width = globalState.bugStats.width + 'px';
            bugElement.style.height = globalState.bugStats.height + 'px';

            bugElement.style.left = playScreen.offsetWidth - globalState.bugStats.width + 'px';
            bugElement.style.top = (playScreen.offsetHeight - globalState.bugStats.height) * Math.random() + 'px';

            playScreen.appendChild(bugElement);
        },
        createFireball: () => {
            let fireballElement = document.createElement('div');
            fireballElement.classList.add('fireball');
            fireballElement.style.width = globalState.fireballStats.width + 'px';
            fireballElement.style.height = globalState.fireballStats.height + 'px';

            fireballElement.style.left = globalState.wizard.x + 'px';
            fireballElement.style.top = globalState.wizard.y + 'px';

            playScreen.appendChild(fireballElement);
        },
        createCloud: () => {
            let cloud = document.createElement('div');
            cloud.classList.add('cloud');

            cloud.style.width = globalState.cloudStats.width + 'px';
            cloud.style.height = globalState.cloudStats.height + 'px';

            cloud.style.left = playScreen.offsetWidth - globalState.cloudStats.width + 'px';
            cloud.style.top = (playScreen.offsetHeight - globalState.cloudStats.height) * Math.random() + 'px';

            playScreen.appendChild(cloud);
        }
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