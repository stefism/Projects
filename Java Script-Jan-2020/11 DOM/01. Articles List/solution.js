function createArticle() {
    let article = document.createElement('article')
    let h3 = document.createElement('h3')
    let p = document.createElement('p')

    let input = document.getElementById('createTitle')
    let textArea = document.getElementById('createContent')
    let articles = document.getElementById('articles')

    if(input.value.length > 0 && textArea.value.length > 0){
        h3.innerHTML = input.value
        p.innerHTML = textArea.value

        article.appendChild(h3)
        article.appendChild(p)

        articles.appendChild(article)

        input.value = ''
        textArea.value = ''
    }

    //debugger
    //TODO...
}