function solve() {
    let middled = document.getElementsByClassName('middled')

    let softUni = middled[0].children[0]
    let google = middled[0].children[1]
    let youTube = middled[0].children[2]
    let wikipedia = middled[0].children[3]
    let gmail = middled[0].children[4]
    let stackOverflow = middled[0].children[5]

    softUni.addEventListener('click', x => increaseCounter(softUni))
    google.addEventListener('click', x => increaseCounter(google))
    youTube.addEventListener('click', x => increaseCounter(youTube))
    wikipedia.addEventListener('click', x => increaseCounter(wikipedia))
    gmail.addEventListener('click', x => increaseCounter(gmail))
    stackOverflow.addEventListener('click', x => increaseCounter(stackOverflow))

    function increaseCounter(link) {
        let p = link.getElementsByTagName('p')
        let text = p[0].innerText
        let count = text.match(/\d+/gi)
        p[0].innerHTML = `visited ${++count} times`
    }
}