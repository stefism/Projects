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
            allWords: ["veganic", "nyctograph", "bibliomania", "farinose"]
        }
        this.handleLetterClick = this.handleLetterClick.bind(this)
    }

    componentDidMount(){
        const randNum = Math.floor(Math.random() * this.state.allWords.length)
        const randomWord = this.state.allWords[randNum]
        this.setState({randomWord: randomWord})
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
                    l.ifClicked = true
                }
                return l
            })
            return {
                letters: updatedLettersIfClicked
            }
        })
        
        console.log("clicked on letter")
        
    }

    render() {
        let allLetters = this.state.letters.map(l => 
            <SingleLetter 
                key={l.id}
                item={l}
                ifClicked={this.handleLetterClick}
            />)

            for(let i = 0; i < allLetters.length; i++){
                
                if(allLetters[i].ifClicked){
                    allLetters[i].classList.add("clicked")
                }
            }

            let randomWord = this.state.randomWord.toUpperCase()
            let randomWordAsArray = []

            for(let i = 0; i < randomWord.length; i++){
                randomWordAsArray.push(randomWord[i])
            }

            let emptyWord = []

            for(let i = 0; i < randomWord.length; i++){
                emptyWord.push("_")
            }

            console.log(randomWordAsArray)
            console.log(emptyWord)

            return(
                <div>
                    <h3 id="empty-word">{emptyWord.join(" ")}</h3>
                    <p>You have {this.state.turnsLeft} turns to guess the word.</p>
                
                <div id="all-letters">
                    {allLetters}
                </div>

                </div>
            )
    }
}

export default Hangman