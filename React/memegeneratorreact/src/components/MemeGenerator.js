import React from "react"

class MemeGenerator extends React.Component {
    constructor(){
        super()
        this.state = {
            topText: "",
            bottomText: "",
            randomImage: "http://i.imgflip.com/1bij.jpg",
            allMemeImgs: []
        }
        this.handleChange = this.handleChange.bind(this)
        this.handleSubmit = this.handleSubmit.bind(this)
    }

    componentDidMount(){
        fetch("https://api.imgflip.com/get_memes")
        .then(response => response.json())
        .then(response => {
            const {memes} = response.data
            // console.log(memes[0])
            this.setState({allMemeImgs: memes})
        })
    }

    handleChange(event){
        // console.log("Working.")
        const {name, value} = event.target
        this.setState({[name]: value})
    }

    handleSubmit(event){
        event.preventDefault()
        const randNum = Math.floor(Math.random() * this.state.allMemeImgs.length)
        const randMemeImg = this.state.allMemeImgs[randNum].url
        this.setState({randomImage: randMemeImg})
    }

    render(){
        return(
            <div>
                <form id="meme-form" onSubmit={this.handleSubmit}>
                    
                    <input type="text" name="topText" 
                    placeholder="Top Text"
                    value={this.state.topText} 
                    onChange={this.handleChange}/>

                    <input type="text" name="bottomText" 
                    placeholder="Bottom Text"
                    value={this.state.bottomText}
                    onChange={this.handleChange} />

                    <button>Generate meme</button>
                </form>

                <div id="meme">
                    <img width="350px" src={this.state.randomImage}/>
                    <h2 id="top-text">{this.state.topText}</h2>
                    <h2 id="bottom-text">{this.state.bottomText}</h2>
                </div>
            </div>
        )
    }
}

export default MemeGenerator