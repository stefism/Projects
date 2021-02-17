import React from "react"

import letters from "./Letters"
import SingleLetter from "./SingleLetter"

class Hangman extends React.Component {
    constructor() {
        super()
        this.state = {
            letters: letters,
            wrongTurn: false,
            isGuess: false,
            turnsLeft: 5,
            randomWord: "",
            allWords: ["PRO", "VAVSDXYZV", "VEGANIK", "NYCTOGRAPH", "BIBLIOMANIA", "FARINOSE"],
            currClickedWord: "",
            wordToFill: []
        }
        this.handleLetterClick = this.handleLetterClick.bind(this)
    }

    componentDidMount(){
        const randNum = Math.floor(Math.random() * this.state.allWords.length)
        const randomWord = this.state.allWords[randNum]
        
        const emptyWord = []

        for(let i = 0; i < randomWord.length; i++){
            emptyWord.push("_")
        }

        this.setState({randomWord: randomWord})
        this.setState({wordToFill: emptyWord})
    }

    // componentDidMount(){
    //     fetch("https://random-word-api.herokuapp.com/all")
    //     .then(response => response.json())
    //     .then(response => {
    //         const {words} = response.data
    //         console.log(words)
    //         // this.setState({allWords: [words]})
    //     })
    // }

    handleLetterClick(id){
        this.setState((prevState) => {
            let updatedLettersIfClicked = prevState.letters.map(l => {
                if(l.id === id){
                    l.isClicked = true
                    this.setState({currClickedWord: l.letter})
                    console.log(this.state.currClickedWord);
                }
                return l
            })
            //debugger;
            return {
                letters: updatedLettersIfClicked
            }
        })
        
        this.clickOnLetterLogic()
        
        console.log("clicked on letter")
    }

    clickOnLetterLogic() {
        if (this.state.randomWord.includes(this.state.currClickedWord)) {

            console.log("CONTAINS")

            let isGuess = this.isWordGuessed(this.state.wordToFill)
            console.log("Is Guess: " + isGuess)

            if (isGuess) {
                this.setState({isGuess: true})
            }

            let letterIndexes = this.getAllLetterIndexes(this.state.randomWord, this.state.currClickedWord)

            let wordCopy = [...this.state.wordToFill]

            for (let i = 0; i < letterIndexes.length; i++) {
                
                let letterIndex = letterIndexes[i]
                
                let letterToChange = { ...wordCopy[letterIndex] }
                letterToChange = this.state.currClickedWord
                wordCopy[letterIndex] = letterToChange
            }

            this.setState({ wordToFill: wordCopy })
            this.setState({wrongTurn: false})

        } else {
            console.log("NOT CONTAINS")
            this.setState(prevState => {
                return { turnsLeft: prevState.turnsLeft - 1 }
            })
            this.setState({wrongTurn: true})
        }
    }

    isWordGuessed(wordArr){
        for (let i = 0; i <= wordArr.length; i++) {          
           if (wordArr[i] === "_") {
               return false
           }

           if (i == wordArr.length && wordArr[i] != "_") {
               return true
           }
        }
    }

    getAllLetterIndexes(array, letter){
        var indexes = [];
        
        for(let i = 0; i < array.length; i++){
            if (array[i] === letter)
            indexes.push(i);
        }
        
        return indexes;
    }

    render() {
        let allLetters = this.state.letters.map(l => 
        <SingleLetter 
            key={l.id}
            item={l}
            ifClicked={this.handleLetterClick}/>
        );

        console.log(this.state.randomWord)
        console.log(this.state.wordToFill)

        if (this.state.isGuess) {
            return (
                <h1>Congratulation! You guess the word!</h1>
            )
        }

        if(this.state.turnsLeft === 0){
            return (
                <h1>GAME OVER. Try Again?</h1>
            )
        }

        let wronTurnStyleRed = {
            color: "red"
        }

        let wrongTurnStyleWhite = {
            color: "white"
        }
        
        return(
            <div>
                <h3 id="empty-word">{this.state.wordToFill.join(" ")}</h3>
                <h3 id="wrong-turn" style={this.state.wrongTurn ? wronTurnStyleRed : wrongTurnStyleWhite}>Wrong turn. Sorry :)</h3>
                <p id="have-turns">You have <span id="turns-left"><b>{this.state.turnsLeft}</b></span> turns to guess the word.</p>
            
            <div id="all-letters">
                {allLetters}
            </div>
            </div>
        )
    }
}

export default Hangman