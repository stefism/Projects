export function setUserData(userData) {
    localStorage.setItem('userData', JSON.stringify(userData));
}

export function getUserData() {
    return JSON.parse(localStorage.getItem('userData'));
}

export function clearUserData() {
    localStorage.removeItem('userData');
}

export function createSubmitHandler(callback, ...fields) {
    return function(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const data = fields.reduce((a, c) => Object.assign(a, {[c]: formData.get(c)}), {});

        callback(data, event);
    };
}

export function parseQuery(queryString) {
    if(queryString == '') {
        return {};
    }

    return queryString.split('&').reduce((accumulator, currElement) => {
        const [key, value] = currElement.split('=');
        accumulator[key] = value;
        return accumulator;
    }, {});
}