function addHero() {
    let heroNameElement = document.getElementById('hero-name');
    let heroListElement = document.getElementById('hero-list');

    let newHeroItemElement = document.createElement('li');
    newHeroItemElement.textContent = heroNameElement.value;

    heroListElement.appendChild(newHeroItemElement);

    //Клониране на вече съществуващ елемент:
    let cloned = heroListElement.children[0].cloneNode(); //Ще направи копие в случая на Superman.
    cloned.textContent = heroNameElement.value;
    heroListElement.appendChild(cloned); //Добавя го като последно. Ако искаме да се добави като първо или най-отпред, прави се с .prepend(cloned).

    heroNameElement.value = '';
}

let heroListElement = document.getElementById('hero-list');
heroListElement.addEventListener('mouseover', showCurrentHeroName);
let currentHeroName = document.getElementById('heroName');

function showCurrentHeroName(e){
    currentHeroName.textContent = e.target.textContent;
    
    console.log(e.target.textContent);
    console.log(e.currentTarget); //heroListElement (ul) е currentTarget, а вътре li-тата в ul са target. currentTarget е това върху което сме закачили ивента.
}

function deleteHero(){
    let heroListElement = document.querySelectorAll('#hero-list li');
    let lastHero = heroListElement[heroListElement.length - 1];
    lastHero.remove();
}