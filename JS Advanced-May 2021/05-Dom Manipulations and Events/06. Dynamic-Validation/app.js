function validate() {
    let email = document.getElementById('email');

    email.addEventListener('change', (e) => {
        let emailValue = email.value;
        const regex = /^[a-z]+@[a-z]+\.[a-z]+$/;
        let isRegexValid = regex.exec(emailValue);

        if(isRegexValid == null){
            email.setAttribute('class', 'error');
        }
        else {
            email.removeAttribute('class');
        }
        console.log(e);
        console.log(emailValue);
        console.log(isRegexValid);
    });
}