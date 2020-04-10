function solve() {
    let input = document.getElementById('input')
    let text = input.innerText.split('. ')

    let output = document.getElementById('output')

    let paragraph = ''
    paragraph += text[0] + '. '

    for (let i = 1; i <= text.length; i++) {
        if(i % 3 === 0){
            let p = document.createElement('p')
            p.innerHTML = paragraph
            output.appendChild(p)
            paragraph = ''
        }

        paragraph += text[i] + '. '

        if(i === text.length && paragraph.length > 2){
            let p = document.createElement('p')
            p.innerHTML = paragraph
            output.appendChild(p)
        }
    }
}