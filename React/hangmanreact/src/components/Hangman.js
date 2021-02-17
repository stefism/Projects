import React from "react"

import letters from "./Letters"
import SingleLetter from "./SingleLetter"

class Hangman extends React.Component {
    constructor() {
        super()
        this.state = {
            letters: letters,
            turnsLeft: 5,
            randomWord: "",
            allWords: ["VEGANIK", "NYCTOGRAPH", "BIBLIOMANIA", "FARINOSE"],
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
        
        if(this.state.randomWord.includes(this.state.currClickedWord)){
            
            console.log("CONTAINS")

            let letterIndex = this.state.randomWord.indexOf(this.state.currClickedWord)

            let wordCopy = [...this.state.wordToFill]
            let letterToChange = {...wordCopy[letterIndex]}
            letterToChange = this.state.currClickedWord
            wordCopy[letterIndex] = letterToChange
            this.setState({wordToFill: wordCopy})
            
        } else {
            console.log("NOT CONTAINS")
            this.setState(prevState => {
                return {turnsLeft: prevState.turnsLeft - 1}
            })
        }
        
        console.log("clicked on letter")
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
        
        return(
            <div>
                <h3 id="empty-word">{this.state.wordToFill.join(" ")}</h3>
                <p id="have-turns">You have <span id="turns-left"><b>{this.state.turnsLeft}</b></span> turns to guess the word.</p>
            
            <div id="all-letters">
                {allLetters}
            </div>
            </div>
        )
    }
}

export default Hangman