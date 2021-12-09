function attachGradientEvents() {
    let gradientBoxElement = document.getElementById('gradient');
    let resultElement = document.getElementById('result');

    gradientBoxElement.addEventListener('mousemove', function(e) {
        console.log(e);
        console.log(e.currentTarget.offsetWidth); // Цялата дължина на елемента в пиксели.
        console.log(e.offsetX); //На колко пиксела на дясно е цъкнато.

        let percent = Math.floor((e.offsetX / e.currentTarget.offsetWidth) * 100);
        resultElement.textContent = percent + '%';
    });
}