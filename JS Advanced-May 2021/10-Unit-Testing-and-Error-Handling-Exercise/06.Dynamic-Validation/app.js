function validate() {
    let emailInput = document.getElementById('email');
    let emailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/;
    
    emailInput.addEventListener('change', () => {
        !emailPattern.test(emailInput.value) ? emailInput.setAttribute('class', 'error') : emailInput.removeAttribute('class');
    });
}