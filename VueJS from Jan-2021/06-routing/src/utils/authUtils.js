export function authMe() {
    const user = {
        name: 'Stefan',
        isAuth: true,
        expiration: new Date().getTime() + 15000
    };

    localStorage.setItem('user', JSON.stringify(user));

    setTimeout(() => {
        user.isAuth = false;
        localStorage.setItem('user', JSON.stringify(user));
    }, 15000);
}

export function getUser() {
    return JSON.parse(localStorage.getItem('user'));
}