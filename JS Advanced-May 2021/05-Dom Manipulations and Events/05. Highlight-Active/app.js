function focused() {
    let inputsFields = document.querySelectorAll('input');

    for(const input of inputsFields){
        input.addEventListener('focus', (e) => {
            let section = e.target.parentNode;
            section.setAttribute('class', 'focused');
        });

        input.addEventListener('blur', (e) => {
            let section = e.target.parentNode;
            section.removeAttribute('class');
        });
    }
}