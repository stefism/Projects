function create(words) {
   let content = document.getElementById('content')

   for (let word = 0; word < words.length; word++) {
      let currDiv = document.createElement('div')
      let currPar = document.createElement('p')
      currPar.innerText = words[word]
      currPar.style.display = 'none'
      currDiv.appendChild(currPar)

      content.appendChild(currDiv)
   }

   content.addEventListener('click', e => showContent(e))

   function showContent(e) {
      let currSection = e.target
      let currPar = currSection.childNodes[0]
      currPar.style.display = 'block'
   }
}