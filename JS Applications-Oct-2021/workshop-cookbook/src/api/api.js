import { notify } from '../lib/notify.js';
import { getUserData, setUserData, clearUserData } from '../util.js';

const hostname = 'https://parseapi.back4app.com';

async function request(url, options) {
    try {
        const responce = await fetch(hostname + url, options);

        if(responce.ok == false) {
            const error = await responce.json();
            throw {
                message: error.error,
                code: error.code
            };
        }

        return responce.json();
    } catch (error) {
        notify(error.message);
        // alert(error.message);
        throw error;
    }
}

function createOptions(method = 'get', data) {
    const options = {
        method,
        headers: {
            'X-Parse-Application-Id': 'PEUIUtKvpsIygq1Wx64zmdT9jjVHN6nZZJSZZ8bU',
            'X-Parse-REST-API-Key': 'nbgKXWIXUfHCbmMkyia0g0YrxNSSrvGGD6EevppN'
        }
    };

    const userData = getUserData();
    
    if(userData) {
        options.headers['X-Parse-Session-Token'] = userData.token;
    }

    if(data) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
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

export async function login(username, password) {
    const result = await post('/login', { username, password });

    const userData = {
        username: result.username,
        id: result.objectId,
        token: result.sessionToken
    };

    setUserData(userData);

    return result;
}

export async function register(username, email, password) {
    const result = await post('/users', { username, email, password });

    const userData = {
        username,
        id: result.objectId,
        token: result.sessionToken
    };

    setUserData(userData);

    return result;
}

export async function logout() {
    await post('/logout');
    clearUserData();
}