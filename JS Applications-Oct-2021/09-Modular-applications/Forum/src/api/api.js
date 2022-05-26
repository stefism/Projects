import { clearUserData, getUserData, setUserData } from '../util.js';

const host = 'http://localhost:3030';

async function request(url, options) {
    try {
        const response = await fetch(host + url, options);

        if (response.ok != true) {
            if (response.status == 403) {
                clearUserData();
            }
            //Против изтекъл токен. Приложението вижда, че има токен, не му позволява да се логне на ново, а сървъра връща невалиден токен (403) - soft lock.
            const error = await response.json();
            throw new Error(error.message);
        }

        if(url == '/users/logout') {
            return;
        }

        if(response.status == 204) { //204 - Empty response
            return response;
        } else {
            return response.json();
        }

    } catch (error) {
        alert(error);
        // notify(error);
        throw error;
    }
}

function createOptions(method = 'get', data) {
    const options = {
        method,
        headers: {}
    };

    if(data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userData = getUserData();
    if (userData != null) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function get(url) {
    return request(url, createOptions());
}

export async function post(url, data) {
    return request(url, createOptions('post', data));
}

export async function put(url, data) {
    return request(url, createOptions('put', data));
}

export async function del(url) {
    return request(url, createOptions('delete'));
}

export async function login(email, password) {
    const result = await post('/users/login', {email, password});

    const userData = {
        email: result.email,
        username: result.username,
        id: result._id,
        token: result.accessToken
    }
    
    setUserData(userData);
}

export async function register(email, username, password) {
    const result = await post('/users/register', {email, username, password});

    const userData = {
        email: result.email,
        username: result.username,
        id: result._id,
        token: result.accessToken
    }

    setUserData(userData);
}

export async function logout() {
    await get('/users/logout');
    clearUserData();
    //Евентуално clearUserData() да е първо, защото ако даде грешка в логаута няма да изчисти данните. Грешка може да има от невалиден токен.
}