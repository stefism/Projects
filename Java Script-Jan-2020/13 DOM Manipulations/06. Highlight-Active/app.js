function focus() {
    let sections = document.querySelector("body > div")
    sections.addEventListener('click', e => onFocus(e))

    function onFocus(e) {
        let currElement = e.target

        if(currElement.tagName === 'INPUT'){
            let currSection = currElement.parentNode
            currSection.classList.add('focused')
            currElement.addEventListener('blur', function () {
                currSection.classList.remove('focused')

            })
        }
        //debugger
    }
}