function validate() {
    let userName = document.getElementById('username');
    let email = document.getElementById('email');
    let password = document.getElementById('password');
    let confirmPassword = document.getElementById('confirm-password');
    let isCompany = document.getElementById('company');
    let companyNumber = document.getElementById('companyNumber');
    let companyInfo = document.getElementById('companyInfo');

    let submitBtn = document.getElementById('submit');
    let divValid = document.getElementById('valid');

    isCompany.addEventListener('click', () => {
        isCompany.checked ? companyInfo.style.display = 'block' : companyInfo.style.display = 'none';
    });

    submitBtn.addEventListener('click', manageValidation);

    function manageValidation(e){
        e.preventDefault();

        let allFieldsIsCorrect = true;

        let userNamePattern = /^[a-zA-Z0-9]{3,20}$/;
        let passwordPattern = /^[\w\d]{5,15}$/;
        let emailPattern = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if(password.value != confirmPassword.value) {
            password.style.borderColor = 'red';
            confirmPassword.style.borderColor = 'red';
            allFieldsIsCorrect = false;
        } else {
            password.style.borderColor = 'black';
            confirmPassword.style.borderColor = 'black';
        }

        if(isCompany.checked){
            let compNumber = Number(companyNumber.value);

            if(compNumber < 1000 || compNumber > 9999){
                companyNumber.style.borderColor = 'red';
                allFieldsIsCorrect = false;
            } else {
                companyNumber.style.border = 'none';
            }
        }

        if(!userNamePattern.test(userName.value)){
            userName.style.borderWidth = '2px';
            userName.style.borderColor = 'red';
            allFieldsIsCorrect = false;
        } else {
            userName.style.borderWidth = '1px';
            userName.style.borderColor = 'black';
        }

        if(!passwordPattern.test(password.value)){
            password.style.borderWidth = '2px';
            password.style.borderColor = 'red';
            allFieldsIsCorrect = false;
        } else {
            password.style.borderWidth = '1px';
            password.style.borderColor = 'black';
        }

        if(!emailPattern.test(email.value)){
            email.style.borderColor = 'red';
            allFieldsIsCorrect = false;
        } else {
            email.style.border = 'none';
        }

        if(allFieldsIsCorrect){
            divValid.style.display = 'block';
        } else {
            divValid.style.display = 'none';
        }
    }
}
