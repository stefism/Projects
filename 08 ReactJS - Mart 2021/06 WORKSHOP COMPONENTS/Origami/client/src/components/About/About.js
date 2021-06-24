const About = ({match, location, history}) => {
    return (
        <main className="main-container">
            <h1>About {match.params.name}</h1>
        </main>
        
    )
}

export default About;