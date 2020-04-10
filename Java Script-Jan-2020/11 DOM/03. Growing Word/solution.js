function growingWord() {
    let text = document.getElementById('exercise').lastElementChild

    if(text.style.color === ''){
        text.style.color = 'blue'
    } else {
        switch (text.style.color) {
            case 'blue': text.style.color = 'green'; break
            case 'green': text.style.color = 'red'; break
            case 'red': text.style.color = 'blue'; break
        }
    }

    if(text.style.fontSize === ''){
        text.style.fontSize = '2px'
    }
    else {
        let fontSize = +text.style.fontSize.slice(0, -2)
        fontSize *= 2
        text.style.fontSize = `${fontSize}px`
    }
}