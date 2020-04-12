function solve() {
    let middled = document.getElementsByClassName('middled')[0]
    //debugger
    for (let i = 0; i < 6; i++) {
        let currElement = middled.children[i]
        //debugger
        currElement.addEventListener('click', x => increaseCounter(currElement))
    }

    function increaseCounter(link) {
        let p = link.getElementsByTagName('p')
        let text = p[0].innerText
        let count = text.match(/\d+/gi)
        p[0].innerHTML = `visited ${++count} times`
    }
}