const host = 'http://localhost:3030';

async function request(url, options) {
    try {
        const response = await fetch(host + url, options);

        if(response.ok != true) {
            if(response.status == 403) {
                sessionStorage.removeItem('userData'); //// Тука се подсигуряваме в случай, че сървъра се рестартира. Тогава чистиме sessionStorage иначе приложението ще си мисли, че е логнато и ще имаме софт лок (няма да можем да се разлогнем). 403 е невалиден токен в този случай.
            }

            const error = await response.json();
            throw new Error(error.message);
        }
        
        if(url == '/users/logout') {
            return;
        }

        if(response.status == 204) {
            return response; //Тука това се прави в случай, че нямаме боди на респонса. Например при logout нямаме боди и при това положение ако нямаме боди и му извикаме .json() ще хвърли грешка. Затова връщаме .json() само ако има боди. 204 = No content. 
        } else {
            return response.json();
        }
    } catch (error) {
        //Тук можем да хванем както грешката от респонса, това е ако сървъра не работи или адреса на сървъра е грешен - Network error ( response = await fetch(url, options) ), така и грешката, която е върнал самия сървър (  if(response.ok != true) ).
        alert(error.message);
        throw error; //Хвърляме грешката и тук за да може и този, който е извикал тази функция, също да разбере, че има грешка. Ако не я хвърлим и тук, я хвълляме мълчаливо и другите функции ще продължат да работят.
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

    const userData = JSON.parse(sessionStorage.getItem('userData'));

    if(userData != null) {
        options.headers['X-Authorization'] = userData.token;
    }

    return options;
}

export async function login(email, password) {
    const responce = await request('/users/login', createOptions('post', { email, password }));

    const userData = {
        email: responce.email,
        id: responce._id,
        token: responce.accessToken
    };

    sessionStorage.setItem('userData', JSON.stringify(userData));
}

export async function register(email, password) {
    const responce = await request('/users/register', createOptions('post', { email, password }));

    const userData = {
        email: responce.email,
        id: responce._id,
        token: responce.accessToken
    };

    sessionStorage.setItem('userData', JSON.stringify(userData));
}

export async function logout() {
    await request('/users/logout', createOptions());
    sessionStorage.removeItem('userData');
}

//rest
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