var state = {
    gameOver: false,
    score: 0,
    wizard: {
        x: 100,
        y: 200,
        width: 82,
        height: 100,
        speed: 10,
        gravity: 2
    },
    bugStats: {
        nextBugCreation: 0,
        maxCreationInterval: 1500,
        speed: 3,
        width: 50,
        height: 50,
    },
    fireballStats: {
        width: 40,
        height: 40,
        speed: 10,
        nextFireball: 0,
        attackSpeed: 400
    },
    cloudStats: {
        nextCloudCreation: 0,
        maxCreationInterval: 12000,
        width: 200,
        height: 200,
        speed: 1,
    },
    keys: {}
};