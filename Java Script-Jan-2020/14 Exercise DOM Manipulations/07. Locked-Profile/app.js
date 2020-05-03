function lockedProfile() {
    let buttons = document.getElementsByTagName('button')
    Array.from(buttons)
        .map(b => b.addEventListener
        ('click', b => processingProfile(b)))

    function processingProfile(b) {
        let currBtn = b.target
        let unlock = currBtn.parentNode.children[4]
        let hiddenFields = currBtn.parentNode.children[9]

        if(unlock.checked === true && currBtn.innerText === 'Show more'){
            hiddenFields.style.display = 'block'
            currBtn.innerText = 'Hide it'
        } else if(unlock.checked === true && currBtn.innerText === 'Hide it'){
            hiddenFields.style.display = 'none'
            currBtn.innerText = 'Show more'
        }
    }
}