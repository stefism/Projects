function gameStateFactory() {
    let state = {
        gameOver: false,
        wizard: {
            x: 100,
            y: 200
        }
    };

    return function() {
        return state;
    }
}