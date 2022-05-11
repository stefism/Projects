import { getMovieById } from './api/data.js';

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

export function loadMovie(ctx, next) {
    const moviePromise = getMovieById(ctx.params.id);
    ctx.moviePromise = moviePromise;
    next();
}