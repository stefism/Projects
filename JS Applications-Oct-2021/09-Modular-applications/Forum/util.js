export function getUserData() {
    return JSON.parse(sessionStorage.getItem('userData'));
}

export function setUserData(data) {
    sessionStorage.setItem('userData', JSON.stringify(data));
}

export function clearUserData() {
    sessionStorage.removeItem('userData');
}

export function getLoginData(targetForm) {
    const formData = new FormData(targetForm);

    const email = formData.get('email');
    const password = formData.get('password');

    return { email, password };
}

export function getAllFormEntriesAsObject(formData) {
    let formElements = {};
    [...formData.entries()].forEach(e => {
        formElements[e[0]] = e[1];
    });

    return formElements;
}

export function parseQuerystring(string) {
    const params = string.split('&')
    .map(p => p.split('='))
    .reduce((a, [k, v]) => Object.assign(a, {[k]: v}), {});
 
    return params;
}

export function verifyFormFields(formElementEntries) {
    let filledValues = {};
    
    Object.entries(formElementEntries).forEach(e => {
        if (e[0] == 'make' && e[1].length < 4) {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required and must be at least 4 character long.`
            }
        } else if (e[0] == 'model' && e[1].length < 4) {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required and must be at least 4 character long.`
            }
        } else if (e[0] == 'year' && (e[1] < 1950 || e[1] > 2050)) {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required and must be between 1950 and 2050.`
            }
        } else if(e[0] == 'description' && e[1].length < 10) {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required and must be be at least 10 character long.`
            }
        } else if (e[0] == 'price' && (e[1] < 0 || e[1] == '')) {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required and must be be a more than zero.`
            }
        } else if(e[0] == 'img' && e[1] == '') {
            filledValues[e[0]] = {
                filled: false,
                errorMsg: `The field ${e[0]} is required.`
            }
        } else {
            filledValues[e[0]] = { filled: true };
        }

        // if (e[1] == '' || e[1] == ' ') {
        //     filledValues[e[0]] = {
        //         filled: false,
        //         errorMsg: `The field ${e[0]} is required.`
        //     };
        // } else {
        //     filledValues[e[0]] = { filled: true };
        // }
    });

    return filledValues;
}