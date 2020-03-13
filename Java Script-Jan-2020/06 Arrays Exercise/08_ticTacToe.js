function ticTacToe(coordinates) {
    let dashBoard = [
        ['false', 'false', 'false'],
        ['false', 'false', 'false'],
        ['false', 'false', 'false']
    ];

    for (let i = 0; i < coordinates.length; i++) {
        if (i % 2 === 0) { //first player
            if (noWins(dashBoard)) {
                console.log('The game ended! Nobody wins :(')
                return printDashBoard(dashBoard)
            }

            let firstPlayerRow = Number(coordinates[i][0])
            let firstPlayerCol = Number(coordinates[i][2])

            if (dashBoard[firstPlayerRow][firstPlayerCol] !== 'false') {
                console.log('This place is already taken. Please choose another!')
                coordinates.splice(i, 1)
                i--
                continue
            }

            dashBoard[firstPlayerRow][firstPlayerCol] = 'X'

            if (haveWinner('X', dashBoard)) {
                console.log('Player X wins!')
                return printDashBoard(dashBoard)
            }
        } else { // second player
            if (noWins(dashBoard)) {
                console.log('The game ended! Nobody wins :(')
                return printDashBoard(dashBoard)
            }

            let secondPlayerRow = Number(coordinates[i][0])
            let secondPlayerCol = Number(coordinates[i][2])

            if (dashBoard[secondPlayerRow][secondPlayerCol] !== 'false') {
                console.log('This place is already taken. Please choose another!')
                coordinates.splice(i, 1)
                i--
                continue
            }

            dashBoard[secondPlayerRow][secondPlayerCol] = 'O'

            if (haveWinner('O', dashBoard)) {
                console.log('Player O wins!')
                return printDashBoard(dashBoard)
            }
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

console.log(ticTacToe(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
));

