function ticTacToe(coordinates) {
    let dashBoard = [
        ['false', 'false', 'false'],
        ['false', 'false', 'false'],
        ['false', 'false', 'false']
    ];

    this.isEnd = false

    for (let i = 0; i < coordinates.length; i++) {
        let player = 'O'

        if (i % 2 === 0) {
            player = 'X'
        }

        playersMoves(i, player, dashBoard)

        if(this.isEnd){
            break
        }
    }

    function playersMoves(i, player, dashBoard) {
        if (noWins(dashBoard)) {
            console.log('The game ended! Nobody wins :(')
            this.isEnd = true
            return printDashBoard(dashBoard)
        }

        let playerRow = Number(coordinates[i][0])
        let playerCol = Number(coordinates[i][2])

        if (dashBoard[playerRow][playerCol] !== 'false') {
            console.log('This place is already taken. Please choose another!')
            coordinates.splice(i, 1)
            i--
            return
        }

        dashBoard[playerRow][playerCol] = `${player}`

        if (haveWinner(`${player}`, dashBoard)) {
            console.log(`Player ${player} wins!`)
            this.isEnd = true
            return printDashBoard(dashBoard)
        }
    }

    function printDashBoard(dashBoard) {
        for (let i = 0; i < 3; i++) {
            console.log(dashBoard[i].join('\t'))
        }
    }

    function haveWinner(playerMark, dashBoard) {
        if (dashBoard[0][0] === playerMark && dashBoard[0][1] === playerMark && dashBoard[0][2] === playerMark) {
            return true
        }

        if (dashBoard[1][0] === playerMark && dashBoard[1][1] === playerMark && dashBoard[1][2] === playerMark) {
            return true
        }

        if (dashBoard[2][0] === playerMark && dashBoard[2][1] === playerMark && dashBoard[2][2] === playerMark) {
            return true
        }

        if (dashBoard[0][0] === playerMark && dashBoard[1][0] === playerMark && dashBoard[2][0] === playerMark) {
            return true
        }

        if (dashBoard[0][1] === playerMark && dashBoard[1][1] === playerMark && dashBoard[2][1] === playerMark) {
            return true
        }

        if (dashBoard[0][2] === playerMark && dashBoard[1][2] === playerMark && dashBoard[2][2] === playerMark) {
            return true
        }

        if (dashBoard[0][0] === playerMark && dashBoard[1][1] === playerMark && dashBoard[2][2] === playerMark) {
            return true
        }

        if (dashBoard[0][2] === playerMark && dashBoard[1][1] === playerMark && dashBoard[2][0] === playerMark) {
            return true
        }

        return false
    }

    function noWins(dashBoard) {
        if (!dashBoard[0].includes('false') && !dashBoard[1].includes('false') && !dashBoard[2].includes('false')) {
            return true
        } else {
            return false
        }
    }
}

console.log(ticTacToe(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
));

