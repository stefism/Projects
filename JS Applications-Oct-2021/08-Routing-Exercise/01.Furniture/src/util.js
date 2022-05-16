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