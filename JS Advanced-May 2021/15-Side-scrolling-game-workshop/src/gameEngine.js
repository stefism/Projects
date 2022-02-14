let game = gameFactory();

        game.startScreen.addEventListener('click', gameStart);

        document.addEventListener('keydown', onKeyDown);
        document.addEventListener('keyup', onKeyUp);

        function gameStart() {
            game.startScreen.classList.add('hidden');
            game.playScreen.classList.remove('hidden');

            window.requestAnimationFrame(gameLoop);
        }

        function gameLoop(timestamp) { //timestamp си го получава по дефолт гейм луупа. Както ивент обжекта подобно. Идва от requestAnimationFrame.
            let { wizard } = state;
            let { wizardElement, scoreScreen } = game;

            modifyWizardPosition(state, game);

            if(state.keys.KeyM) {
                wizardElement.style.backgroundImage = "url('../src/images/wizard-fire.png')";
                
                if(state.fireballStats.nextFireball < timestamp) {
                    game.createFireball();
                    state.fireballStats.nextFireball = timestamp + state.fireballStats.attackSpeed;
                }  
            } else {
                wizardElement.style.backgroundImage = "url('../src/images/wizard.png')";
            }

            Array.from(document.getElementsByClassName('fireball')).forEach(ball => {
                let currentPosition = parseInt(ball.style.left);

                if(currentPosition + state.fireballStats.width < game.playScreen.offsetWidth) {
                    ball.style.left = currentPosition + state.fireballStats.speed + 'px';
                } else {
                    ball.remove();
                }

                Array.from(document.getElementsByClassName('bug')).forEach(bug => {
                    if(checkCollision(ball, bug)) {
                        bug.remove();
                        ball.remove();
                        state.score += 5;
                    }
                });
            });

            Array.from(document.getElementsByClassName('cloud')).forEach(cloud => {
                let currentPosition = parseInt(cloud.style.left); //parseInt - ако има 10px примерно в това дето парсва, ще вземе като число само десетката.
                
                if(currentPosition > 0) {
                    cloud.style.left = currentPosition - state.cloudStats.speed + 'px';
                } else {
                    cloud.remove();
                }
            });

            Array.from(document.getElementsByClassName('bug')).forEach(bug => {
                let currentPosition = parseInt(bug.style.left); //parseInt - ако има 10px примерно в това дето парсва, ще вземе като число само десетката.
                
                if(currentPosition > 0) {
                    bug.style.left = currentPosition - state.bugStats.speed + 'px';
                } else {
                    bug.remove();
                }
                
                if(checkCollision(wizardElement, bug)) {
                    state.gameOver = true;
                }
            });

            if(state.bugStats.nextBugCreation < timestamp) {
                game.createBug();
                state.bugStats.nextBugCreation = timestamp + Math.random() * state.bugStats.maxCreationInterval;
            }

            if(state.cloudStats.nextCloudCreation < timestamp) {
                game.createCloud();
                state.cloudStats.nextCloudCreation = timestamp + Math.random() * state.cloudStats.maxCreationInterval;
            }

            state.bugStats.speed += 0.001;
            
            wizardElement.style.top = wizard.y + 'px';
            wizardElement.style.left = wizard.x + 'px';
            scoreScreen.textContent = `Keys: (A - left, D - right, W - up, S - down, Fire - M) Points: ${state.score.toFixed(2)}`;

            if(!state.gameOver) {
                state.score += 0.01;
                window.requestAnimationFrame(gameLoop);
            } else {
                alert('Game Over');
            }
        }

        function modifyWizardPosition(state, game) {
            let wizard = state.wizard;

            let isLowerBound = wizard.y + wizard.height >= game.playScreen.offsetHeight;

            if(!isLowerBound) {
                wizard.y += wizard.gravity;
            }
            
            if(state.keys.KeyW && wizard.y > 0) {
                wizard.y -= wizard.speed;
            }

            if(state.keys.KeyS && !isLowerBound) {
                wizard.y += wizard.speed;
            }

            if(state.keys.KeyA && wizard.x > 0) {
                wizard.x -= wizard.speed;
            }

            if(state.keys.KeyD && wizard.x + wizard.width < game.playScreen.offsetWidth) {
                wizard.x += wizard.speed;
            }
        }

        function checkCollision(firstElement, secondElement) {
            let first = firstElement.getBoundingClientRect();
            let second = secondElement.getBoundingClientRect();

            return !(first.top > second.bottom || first.bottom < second.top || first.right < second.left || first.left > second.right);
            
        }

        function onKeyDown(e) {
            state.keys[e.code] = true; //.code - дава информация кой клавиш е натиснат.
        }

        function onKeyUp(e) {
            state.keys[e.code] = false; //.code - дава информация кой клавиш е натиснат.
        }