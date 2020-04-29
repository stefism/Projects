function attachGradientEvents() {
    let gradient = document.getElementById('gradient')
    let result = document.getElementById('result')
    gradient.addEventListener('mousemove', e => displayPercent(e))

    function displayPercent(event) {
        result.innerText = `${Math.floor(event.offsetX / 300 * 100)}%`
    }
}